namespace MemberPoint.Entity.POCOModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MemberPointModel : DbContext
    {
        public MemberPointModel()
            : base("name=MemberPointModel")
        {
        }

        public virtual DbSet<CardLevels> CardLevels { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ConsumeOrders> ConsumeOrders { get; set; }
        public virtual DbSet<ExchangGifts> ExchangGifts { get; set; }
        public virtual DbSet<ExchangLogs> ExchangLogs { get; set; }
        public virtual DbSet<MemCards> MemCards { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }
        public virtual DbSet<SysLogs> SysLogs { get; set; }
        public virtual DbSet<TransferLogs> TransferLogs { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ConsumeOrderCategoryItem> ConsumeOrderCategoryItem { get; set; }
        public virtual DbSet<VW_ExchangLogMemCard> VW_ExchangLogMemCard { get; set; }
        public virtual DbSet<VW_MemCardCardLevel> VW_MemCardCardLevel { get; set; }
        public virtual DbSet<VW_ShopCategoryItem> VW_ShopCategoryItem { get; set; }
        public virtual DbSet<VW_UserCategoryItems> VW_UserCategoryItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .Property(e => e.C_Category)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .Property(e => e.C_Illustration)
                .IsUnicode(false);

            modelBuilder.Entity<Shops>()
                .Property(e => e.S_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Shops>()
                .Property(e => e.S_ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<Shops>()
                .Property(e => e.S_ContactTel)
                .IsUnicode(false);

            modelBuilder.Entity<Shops>()
                .Property(e => e.S_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Shops>()
                .Property(e => e.S_Remark)
                .IsUnicode(false);

            modelBuilder.Entity<TransferLogs>()
                .Property(e => e.TL_TransferMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TransferLogs>()
                .Property(e => e.TL_Remark)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumeOrderCategoryItem>()
                .Property(e => e.C_Category)
                .IsUnicode(false);

            modelBuilder.Entity<ConsumeOrderCategoryItem>()
                .Property(e => e.CI_Name)
                .IsUnicode(false);

            modelBuilder.Entity<VW_ShopCategoryItem>()
                .Property(e => e.S_Name)
                .IsUnicode(false);

            modelBuilder.Entity<VW_ShopCategoryItem>()
                .Property(e => e.S_ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<VW_ShopCategoryItem>()
                .Property(e => e.S_ContactTel)
                .IsUnicode(false);

            modelBuilder.Entity<VW_ShopCategoryItem>()
                .Property(e => e.S_Address)
                .IsUnicode(false);

            modelBuilder.Entity<VW_ShopCategoryItem>()
                .Property(e => e.S_Remark)
                .IsUnicode(false);

            modelBuilder.Entity<VW_ShopCategoryItem>()
                .Property(e => e.C_Category)
                .IsUnicode(false);

            modelBuilder.Entity<VW_ShopCategoryItem>()
                .Property(e => e.CI_Name)
                .IsUnicode(false);

            modelBuilder.Entity<VW_UserCategoryItems>()
                .Property(e => e.C_Category)
                .IsUnicode(false);

            modelBuilder.Entity<VW_UserCategoryItems>()
                .Property(e => e.CI_Name)
                .IsUnicode(false);
        }
    }
}
