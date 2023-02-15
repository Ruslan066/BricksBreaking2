using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

using BricksBreaking2Core;
using BricksBreaking2Core.Core;
using BricksBreaking2Core.Service;
using BricksBreaking2Core.Entity;

namespace BricksBreaking2Web.Controllers
{
    public class BricksController : Controller
    {
        private const string FieldSessionKey = "field";


        public IActionResult ChangeColor()
        {
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            string[] symb = { "1", "2", "3", "4", "5" };
            
            string newColor = symb[new Random().Next(0, symb.Length)];
            string oldColor;
            bool exist = true;
            bool exist2 = true;

            do
            {
                oldColor = symb[new Random().Next(0, symb.Length)];
                for (int i = 0; i < field.rowCount; i++)
                    for (int j = 0; j < field.columnCount; j++)
                        if (field.field[i, j] == oldColor)
                            exist = false;

            } while (exist);

            do
            {
                if (newColor == oldColor)
                {
                    newColor = symb[new Random().Next(0, symb.Length)];
                    if (newColor != oldColor)
                        exist2 = false;
                }
                else
                {
                    exist2 = false;
                }

            } while (exist2);

            for (int i = 0; i < field.rowCount; i++)
                for (int j = 0; j < field.columnCount; j++)
                    if(field.field[i, j] == oldColor)
                        field.field[i, j] = newColor;

            HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Index", field);
        }


            public IActionResult Index()
        {

            //var field = new Field(_Row, _Column, 0, 0);
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DataBase>));

            using (FileStream fs = new FileStream("db.xml", FileMode.OpenOrCreate))
            {
                field.dataBases = xmlSerializer.Deserialize(fs) as List<DataBase>;

            }
            HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Index", field);
        }

        public IActionResult Reload()
        {

            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            string name = field.newName;
            var fieldNew = new Field(field.rowCount, field.columnCount, 0, 0);
            fieldNew.newName = name;
            fieldNew.dataBases = field.dataBases;
            HttpContext.Session.SetObject(FieldSessionKey, fieldNew);
            return View("Index", fieldNew);
        }
        public IActionResult SetComment(string comment_)
        {
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            field.newComment = comment_;
            HttpContext.Session.SetObject(FieldSessionKey, field);


            return View("Index", field);
        }

        public IActionResult Destroy(int x, int y)
        {
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);

            var brick = new Brick(field, x, y);
            brick.Destroy();

            HttpContext.Session.SetObject(FieldSessionKey, field);
            if (!Win(field))
            {
                field.dataBases.Add(new DataBase()
                {
                    Players = field.newName,
                    Scores = field.score,
                    Clicks = field.click,
                    Dates = DateTime.Now,
                    Comment = field.newComment,


                });
                field.SortedList();


                save(field.dataBases);
                return View("Win", field);
            }
            return View("Index", field);
        }
        public IActionResult Play(string Player, int row, int column)
        {

            var field = new Field(row, column, 0, 0);
            field.newName = Player;
            field.newComment = "---";
            //load(field.dataBases);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DataBase>));

            using (FileStream fs = new FileStream("db.xml", FileMode.OpenOrCreate))
            {
                field.dataBases = xmlSerializer.Deserialize(fs) as List<DataBase>;

            }


            HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Index", field);

        }



        public static bool Win(Field field)
        {
            for (int i = 0; i < field.rowCount; i++)
                for (int j = 0; j < field.columnCount; j++)
                    if (field.field[i, j] != "-")
                        return true;
            return false;

        }

        public static void save(List<DataBase> list)
        {
            System.IO.File.Delete("db.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DataBase>));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("db.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, list);

                Console.WriteLine("Object has been serialized");
            }
        }
        public static T DeserializeFromXml<T>(string xml)
        {
            T result;
            var ser = new XmlSerializer(typeof(T));
            using (var tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }
        public static void load(List<DataBase> listw)
        {
            //FileStream fse = new FileStream("SCOREE.xml", FileMode.OpenOrCreate);
            //list = XmlUtilnew.Deserialize(typeof(List<Score>), fse) as List<Score>;
            //fse.Close();

            FileStream fse = new FileStream("db.xml", FileMode.OpenOrCreate);
            listw = XmlUtil.Deserialize(typeof(List<DataBase>), fse) as List<DataBase>;
            foreach (DataBase stu in listw)
            {
                Console.WriteLine(stu.Players + "," + stu.Scores.ToString() + "," + stu.Clicks.ToString() + "," + stu.Dates.ToString());
            }



        }
    }
    public class XmlUtilnew
    {
        #region deserialization
        // deserialization
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
        // deserialization
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region serialization
        // serialization
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //Serialized object
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }
        #endregion
    }
}
