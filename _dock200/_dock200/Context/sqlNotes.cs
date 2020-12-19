//using _dock200.Data;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

//namespace _dock200.Context
//{
//    public class sqlNotes
//    {
//        [NotMapped] _DBC _dbc;

//        public void getDb()
//        {
//            //using (_dbc)
//            //{
//            //    var books = _dbc.Query.FromSqlRaw("SELECT BookId, Title FROM Books").ToList();
//            //}
//        }


//        //_________________Raw SQL Queries________________________________
//        //https://docs.microsoft.com/en-us/ef/core/querying/raw-sql#passing-parameters
//        //https://www.learnentityframeworkcore.com/raw-sql


//        //        //_________________
//        //        var blogs = context.Blogs.FromSqlRaw("SELECT * FROM dbo.Blogs").ToList();
//        //        var blogs2 = context.Blogs.FromSqlRaw("EXECUTE dbo.GetMostPopularBlogs").ToList();
//        //        var user = "johndoe"; var blog3 = context.Blogs.FromSqlRaw("EXECUTE dbo.GetMostPopularBlogsForUser {0}", user).ToList();
//        //        var user2 = "johndoe2"; var blogs = context.Blogs.FromSqlInterpolated($"EXECUTE dbo.GetMostPopularBlogsForUser {user}").ToList();


//        //        //_________________
//        //        var user = new SqlParameter("user", "johndoe");
//        //        var blogs = context.Blogs.FromSqlRaw("EXECUTE dbo.GetMostPopularBlogsForUser @user", user).ToList();


//        //        //_________________
//        //        var user = new SqlParameter("user", "johndoe");
//        //        var blogs = context.Blogs.FromSqlRaw("EXECUTE dbo.GetMostPopularBlogsForUser @filterByUser=@user", user).ToList();



//        //        //_________________
//        //        var searchTerm = ".NET";
//        //        var blogs = context.Blogs.FromSqlInterpolated($"SELECT * FROM dbo.SearchBlogs({searchTerm})").Where(b => b.Rating > 3).OrderByDescending(b => b.Rating).ToList();


//        //        //_________________
//        //        //SELECT[b].[BlogId], [b].[OwnerId], [b].[Rating], [b].[Url]
//        //        //FROM(SELECT* FROM dbo.SearchBlogs(@p0)) AS[b] WHERE[b].[Rating] > 3ORDER BY[b].[Rating]
//        //        //DESC





//        ////_________________
//        //var searchTerm = ".NET";
//        //var blogs = context.Blogs.FromSqlInterpolated($"SELECT * FROM dbo.SearchBlogs({searchTerm})").Include(b => b.Posts).ToList();



//        //        //_________________
//        //        var searchTerm = ".NET";
//        //        var blogs = context.Blogs.FromSqlInterpolated($"SELECT * FROM dbo.SearchBlogs({searchTerm})").AsNoTracking().ToList();





//        //                //        //_________________
//        //        using(var context = new SampleContext())
//        //{
//        //    var commandText = "INSERT Categories (CategoryName) VALUES (@CategoryName)";
//        //    var name = new SqlParameter("@CategoryName", "Test");
//        //    context.Database.ExecuteSqlCommand(commandText, name);
//        //}




//        //        //        //_________________
//        //using(var context = new SampleContext())
//        //{
//        //    var name = new SqlParameter("@CategoryName", "Test");
//        //context.Database.ExecuteSqlCommand("EXEC AddCategory @CategoryName", name);
//        //}



//        //         //_________________
//        //        using (var context = new SampleContext())
//        //using (var command = context.Database.GetDbConnection().CreateCommand())
//        //{
//        //    command.CommandText = "SELECT * From Table1";
//        //    context.Database.OpenConnection();
//        //    using (var result = command.ExecuteReader())
//        //    {
//        //        // do something with result
//        //    }
//        //}














//    }
//}
