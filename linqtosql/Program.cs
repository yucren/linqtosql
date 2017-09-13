using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqtosql
{
    class Program
    {
        static void Main(string[] args)
        {
            studentmanagerDataContext stu = new studentmanagerDataContext();

            //foreach (var item in stu.GetTable<Class>())
            //{
            //    Console.WriteLine(item.Name);

            //}
            string[] name = { "yuchengren" };
           
            var stud = from s in stu.Class
                       where name.Contains(s.Name)

                       select
                       new
                       {
                           s.ID,
                           s.Name
                       };


            foreach (var item in stud)
            {
                Console.WriteLine(item.Name);
            }
            //add();
            //edit(1);
            delete(1);
        }

        static void add()  //插入操作
        {
            Class aclass = new Class
            {
                ID = 6,
                Name = "yuchengren",
                PrimaryTeacherID = 1

            };
            Console.WriteLine("----------begin Add a student");
            using (studentmanagerDataContext db =new studentmanagerDataContext())
            {
                db.Log = Console.Out;
                db.Class.InsertOnSubmit(aclass);
                
                db.SubmitChanges();
            }
            Console.WriteLine("----------End Add a student");
        }
        static void edit(int id)    //更新操作
        {
            Console.WriteLine("----------begin edit");
            using (studentmanagerDataContext db =new studentmanagerDataContext())
            {
                db.Log = Console.Out;
                var editclass = db.Class.SingleOrDefault(s => s.ID == id);
                if (editclass ==null)
                {
                    Console.WriteLine("id错误");
                    return;
                }
                editclass.Name = "hello world";
                editclass.PrimaryTeacherID = 3;
                db.SubmitChanges();
                Console.WriteLine("---------end edit Student");
            }
        }
        static void delete(int id) //删除操作
        {
            Console.WriteLine("-----------begin delete a student");
                      using (studentmanagerDataContext db = new studentmanagerDataContext())
            {
                db.Log = Console.Out;
                var editclass = db.Class.SingleOrDefault(s => s.ID == id);
                if (editclass == null)
                {
                    Console.WriteLine("id错误");
                    return;
                }
                db.Class.DeleteOnSubmit(editclass);
                db.SubmitChanges();
                Console.WriteLine("------------end Delete student");
            }
        }

    }
}
