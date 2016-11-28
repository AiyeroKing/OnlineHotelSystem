namespace OnLineHotelOs
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OsDatabase : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“OsDatabase”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“OnLineHotelOs.OsDatabase”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“OsDatabase”
        //连接字符串。
        public OsDatabase()
            : base("name=OsDatabase")
        {
        }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomArticle> RoomArticles { set; get; }
        public virtual DbSet<Admain> Admins { get; set; }
        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var roomTable = modelBuilder.Entity<Room>();
            var roomArticleTable = modelBuilder.Entity<RoomArticle>();
            var AdminTable = modelBuilder.Entity<Admain>();
            AdminTable.HasKey(o => o.Id);
            roomTable.HasKey(o => o.Id);
            roomArticleTable.HasKey(o => o.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    public class Admain
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserMima { get; set; }
    }
    public class Room
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 博客
        /// </summary>
        public string Title { get; set; }

    }
    public class RoomArticle
    {
        public int Id { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Khname { get; set; } //客户姓名
        /// <summary>
        /// 文章内容
        /// </summary>

        public int Khage { get; set; }//客户年龄
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Khsex { get; set; }//客户性别
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Khid { get; set; }//客户身份证
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Khphone { get; set; }//客户联系方式
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Roomid { get; set; }//入住人姓名
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Rzid { get; set; }//入住人身份证
        /// <summary>
        /// 文章内容
        /// </summary>
        public DateTime Rzdate { get; set; }//入住时间
        /// <summary>
        /// 文章内容
        /// </summary>
        /// 
        public DateTime RzTfdate { get; set; }//退房时间
        /// <summary>
        /// 文章内容
        /// </summary>
        /// 
        public string Subject { get; set; }//预定人姓名
        /// <summary>
        /// 文章内容
        /// </summary>



        public string Body { get; set; }//备注

        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime DateCreated { get; set; }
    }
}