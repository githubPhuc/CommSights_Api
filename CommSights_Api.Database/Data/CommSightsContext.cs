using CommSights_Api.Database.ModelCommSights;
using Microsoft.EntityFrameworkCore;

namespace CommSights_Api.Data.ModelCommSights
{
    public partial class CommSightsContext : DbContext
    {
        public CommSightsContext()
        {
        }

        public CommSightsContext(DbContextOptions<CommSightsContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TmpUploadExcelMonthly> TmpUploadExcelMonthlies { get; set; }
        public virtual DbSet<ExcelUploadGoogleSearch> ExcelUploadGoogleSearches { get; set; }
        public virtual DbSet<ApiCountQuery> ApiCountQueries { get; set; }
        public virtual DbSet<ApiGoogle> ApiGoogles { get; set; }
        public virtual DbSet<ApiGoogleSamsung> ApiGoogleSamsungs { get; set; }
        public virtual DbSet<ApiUrl> ApiUrls { get; set; }
        public virtual DbSet<ApisearchRecord> ApisearchRecords { get; set; }
        public virtual DbSet<ApisearchRecordLog> ApisearchRecordLogs { get; set; }
        public virtual DbSet<ApisearchRecordS24> ApisearchRecordS24s { get; set; }
        public virtual DbSet<BaiVietUpload> BaiVietUploads { get; set; }
        public virtual DbSet<BaiVietUploadCount> BaiVietUploadCounts { get; set; }
        public virtual DbSet<CategoryAccount> CategoryAccounts { get; set; }
        public virtual DbSet<CompanyColor> CompanyColors { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<CrawlDataRecord> CrawlDataRecords { get; set; }
        public virtual DbSet<EmailStorage> EmailStorages { get; set; }
        public virtual DbSet<EmailStorageProperty> EmailStorageProperties { get; set; }
        public virtual DbSet<GetCodeHtml> GetCodeHtmls { get; set; }
        public virtual DbSet<KeySearchSamsung> KeySearchSamsungs { get; set; }
        public virtual DbSet<KeywordSearch> KeywordSearches { get; set; }
        public virtual DbSet<LinkCommSight> LinkCommSights { get; set; }
        public virtual DbSet<ListUrl> ListUrls { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<MembershipAccessHistory> MembershipAccessHistories { get; set; }
        public virtual DbSet<MembershipPermission> MembershipPermissions { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductMonthly> ProductMonthlies { get; set; }
        public virtual DbSet<ProductPermission> ProductPermissions { get; set; }
        public virtual DbSet<ProductProperty> ProductProperties { get; set; }
        public virtual DbSet<ProductPropertyMonthly> ProductPropertyMonthlies { get; set; }
        public virtual DbSet<ProductSearch> ProductSearches { get; set; }
        public virtual DbSet<ProductSearchProperty> ProductSearchProperties { get; set; }
        public virtual DbSet<ProductTest> ProductTests { get; set; }
        public virtual DbSet<ReportMonthly> ReportMonthlies { get; set; }
        public virtual DbSet<ReportMonthlyProperty> ReportMonthlyProperties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const int commandTimeoutInSeconds = 3600;
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=103.147.122.150;Initial Catalog=CommSights;Persist Security Info=True;User ID=sa;Password=@@@CommSights123@@@;Trust Server Certificate=True", options =>
                {
                    options.CommandTimeout(commandTimeoutInSeconds);
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TmpUploadExcelMonthly>(entity =>
            {
                entity.ToTable("TmpUploadExcelMonthly");

                entity.Property(e => e.CorpCopy).HasColumnName("Corp_Copy");

                entity.Property(e => e.FeatureCorp).HasColumnName("Feature_Corp");

                entity.Property(e => e.FeatureProduct).HasColumnName("Feature_Product");

                entity.Property(e => e.FeatureValue).HasColumnName("Feature_Value");

                entity.Property(e => e.HeadlineValue).HasColumnName("Headline_Value");

                entity.Property(e => e.MainCategory).HasColumnName("Main_Category");

                entity.Property(e => e.Mps).HasColumnName("MPS");

                entity.Property(e => e.PictureValue).HasColumnName("Picture_Value");

                entity.Property(e => e.ProductName).HasColumnName("Product_Name");

                entity.Property(e => e.RomeCorp).HasColumnName("ROME_Corp");

                entity.Property(e => e.RomeProduct).HasColumnName("ROME_Product");

                entity.Property(e => e.SegmentProduct).HasColumnName("Segment_Product");

                entity.Property(e => e.SentimentCorp).HasColumnName("Sentiment_Corp");

                entity.Property(e => e.SentimentProduct).HasColumnName("Sentiment_Product");

                entity.Property(e => e.SoeCorp).HasColumnName("SOE_Corp");

                entity.Property(e => e.SoeProduct).HasColumnName("SOE_Product");

                entity.Property(e => e.SpokePersonName).HasColumnName("Spoke_Person_Name");

                entity.Property(e => e.SpokePersonTitle).HasColumnName("Spoke_Person_Title");

                entity.Property(e => e.SpokePersonValue).HasColumnName("Spoke_Person_Value");

                entity.Property(e => e.SubCategory).HasColumnName("Sub_Category");

                entity.Property(e => e.TierCommSights).HasColumnName("Tier_CommSights");

                entity.Property(e => e.TierCustomer).HasColumnName("Tier_Customer");

                entity.Property(e => e.TierValue).HasColumnName("Tier_Value");

                entity.Property(e => e.ToneValue).HasColumnName("Tone_Value");

                entity.Property(e => e.Url).HasColumnName("URL");
            });
            modelBuilder.Entity<ApiCountQuery>(entity =>
            {
                entity.ToTable("API_CountQuery");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");
            });


            modelBuilder.Entity<ApiGoogle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ApiGoogle");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IsHieuluc).HasColumnName("isHieuluc");

                entity.Property(e => e.Param)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApiGoogleSamsung>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ApiGoogle_Samsung");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IsHieuluc).HasColumnName("isHieuluc");

                entity.Property(e => e.Param)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<ExcelUploadGoogleSearch>(entity =>
            {
                entity.ToTable("ExcelUploadGoogleSearch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("Date_");

                entity.Property(e => e.HeadlineVn).HasColumnName("HeadlineVN");

                entity.Property(e => e.HeadlineVnhyperlink).HasColumnName("HeadlineVNHyperlink");
            });
            modelBuilder.Entity<ApiUrl>(entity =>
            {
                entity.ToTable("API_Url");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Method).HasMaxLength(10);

                entity.Property(e => e.Url).HasMaxLength(250);
            });

            modelBuilder.Entity<ApisearchRecord>(entity =>
            {
                entity.ToTable("APISearch_Record");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Displaylink).HasMaxLength(100);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.SearchByList).HasMaxLength(100);

                entity.Property(e => e.UrlApi)
                    .HasMaxLength(500)
                    .HasColumnName("Url_API");
            });

            modelBuilder.Entity<ApisearchRecordLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("APISearch_Record_log");

                entity.Property(e => e.Author).HasMaxLength(500);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Displaylink).HasMaxLength(100);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.KeySearch).HasMaxLength(500);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.UrlApi)
                    .HasMaxLength(500)
                    .HasColumnName("Url_API");
            });

            modelBuilder.Entity<ApisearchRecordS24>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("APISearch_Record_S24");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Displaylink).HasMaxLength(100);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.SearchByList).HasMaxLength(100);

                entity.Property(e => e.UrlApi)
                    .HasMaxLength(500)
                    .HasColumnName("Url_API");
            });

            modelBuilder.Entity<BaiVietUpload>(entity =>
            {
                entity.ToTable("BaiVietUpload");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.Urlcode)
                    .HasMaxLength(4000)
                    .HasColumnName("URLCode");
            });

            modelBuilder.Entity<BaiVietUploadCount>(entity =>
            {
                entity.ToTable("BaiVietUploadCount");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<CategoryAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CategoryAccount");

                entity.Property(e => e.CategoryAccount1)
                    .HasMaxLength(250)
                    .HasColumnName("Category_Account");

                entity.Property(e => e.CategorySubIndustry)
                    .HasMaxLength(250)
                    .HasColumnName("CategorySub_Industry");

                entity.Property(e => e.CompanyName).HasMaxLength(500);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<CompanyColor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Company_Color");

                entity.Property(e => e.Color).HasMaxLength(1000);

                entity.Property(e => e.CompanyName).HasMaxLength(500);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("Config");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(4000);

                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.CodeName).HasMaxLength(4000);

                entity.Property(e => e.CodeNameSub).HasMaxLength(4000);

                entity.Property(e => e.ColorTypeId).HasColumnName("ColorTypeID");

                entity.Property(e => e.Controller).HasMaxLength(4000);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.FrequencyId).HasColumnName("FrequencyID");

                entity.Property(e => e.GroupName).HasMaxLength(4000);

                entity.Property(e => e.Icon).HasMaxLength(4000);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.TierId).HasColumnName("TierID");

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.Urlfull)
                    .HasMaxLength(4000)
                    .HasColumnName("URLFull");

                entity.Property(e => e.Urlsub)
                    .HasMaxLength(4000)
                    .HasColumnName("URLSub");
            });

            modelBuilder.Entity<CrawlDataRecord>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CrawlData_Record");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.KeySearch)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UrlCode)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailStorage>(entity =>
            {
                entity.ToTable("EmailStorage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateRead).HasColumnType("datetime");

                entity.Property(e => e.DateSend).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Display).HasMaxLength(4000);

                entity.Property(e => e.EmailBcc)
                    .HasMaxLength(4000)
                    .HasColumnName("EmailBCC");

                entity.Property(e => e.EmailCc)
                    .HasMaxLength(4000)
                    .HasColumnName("EmailCC");

                entity.Property(e => e.EmailFrom).HasMaxLength(4000);

                entity.Property(e => e.EmailTo).HasMaxLength(4000);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Password).HasMaxLength(4000);

                entity.Property(e => e.Smtpport).HasColumnName("SMTPPort");

                entity.Property(e => e.Smtpserver)
                    .HasMaxLength(4000)
                    .HasColumnName("SMTPServer");

                entity.Property(e => e.Subject).HasMaxLength(4000);
            });

            modelBuilder.Entity<EmailStorageProperty>(entity =>
            {
                entity.ToTable("EmailStorageProperty");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateRead).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(4000);

                entity.Property(e => e.FileName).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title).HasMaxLength(4000);
            });

            modelBuilder.Entity<GetCodeHtml>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Get_CodeHTML");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DatePublishCode)
                    .HasMaxLength(1000)
                    .HasColumnName("DatePublish_Code");

                entity.Property(e => e.DescriptionCode)
                    .HasMaxLength(1000)
                    .HasColumnName("Description_Code");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Site)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TitleCode)
                    .HasMaxLength(1000)
                    .HasColumnName("Title_Code");
            });

            modelBuilder.Entity<KeySearchSamsung>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("KeySearch_Samsung");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<KeywordSearch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Keyword_Search");

                entity.Property(e => e.Account).HasMaxLength(500);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");
            });

            modelBuilder.Entity<LinkCommSight>(entity =>
            {
                entity.ToTable("Link_CommSights");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName).HasMaxLength(500);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DatePublish).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.LinkCrm).HasColumnName("LinkCRM");

                entity.Property(e => e.MediaTitle).HasMaxLength(500);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Urlcode).HasColumnName("URLCode");
            });

            modelBuilder.Entity<ListUrl>(entity =>
            {
                entity.ToTable("ListURL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Urlfull)
                    .HasMaxLength(4000)
                    .HasColumnName("URLFull");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("Membership");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AcceptanceForm)
                    .HasMaxLength(4000)
                    .HasColumnName("Acceptance_Form");

                entity.Property(e => e.Account).HasMaxLength(4000);

                entity.Property(e => e.Address).HasMaxLength(4000);

                entity.Property(e => e.Avatar).HasMaxLength(4000);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CitizenIdentification).HasMaxLength(4000);

                entity.Property(e => e.Color).HasMaxLength(1000);

                entity.Property(e => e.ContactMethod)
                    .HasMaxLength(4000)
                    .HasColumnName("Contact_Method");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(500)
                    .HasColumnName("Contact_No");

                entity.Property(e => e.ContactProcess)
                    .HasMaxLength(4000)
                    .HasColumnName("Contact_Process");

                entity.Property(e => e.ContactValue)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Contact_Value");

                entity.Property(e => e.ContactValue1month)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Contact_Value1month");

                entity.Property(e => e.DateBegin).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(4000);

                entity.Property(e => e.EnglishName).HasMaxLength(4000);

                entity.Property(e => e.FirstName).HasMaxLength(4000);

                entity.Property(e => e.FullName).HasMaxLength(4000);

                entity.Property(e => e.Guicode)
                    .HasMaxLength(4000)
                    .HasColumnName("GUICode");

                entity.Property(e => e.InvoiceForm)
                    .HasMaxLength(4000)
                    .HasColumnName("Invoice_Form");

                entity.Property(e => e.IsIrisDashBoardPlus).HasColumnName("IsIrisDashBoard_Plus");

                entity.Property(e => e.LastName).HasMaxLength(4000);

                entity.Property(e => e.MailCustomerService)
                    .HasMaxLength(4000)
                    .HasColumnName("Mail_CustomerService");

                entity.Property(e => e.MailSendCs)
                    .HasMaxLength(4000)
                    .HasColumnName("MailSend_CS");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Passport).HasMaxLength(4000);

                entity.Property(e => e.Password).HasMaxLength(4000);

                entity.Property(e => e.PaymentForm)
                    .HasMaxLength(4000)
                    .HasColumnName("Payment_Form");

                entity.Property(e => e.Phone).HasMaxLength(4000);

                entity.Property(e => e.Points).HasColumnType("money");

                entity.Property(e => e.ShortName).HasMaxLength(4000);

                entity.Property(e => e.Status).HasMaxLength(4000);

                entity.Property(e => e.TaxCode).HasMaxLength(4000);

                entity.Property(e => e.Website).HasMaxLength(4000);
            });

            modelBuilder.Entity<MembershipAccessHistory>(entity =>
            {
                entity.ToTable("MembershipAccessHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action).HasMaxLength(4000);

                entity.Property(e => e.Controller).HasMaxLength(4000);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateTrack).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.QueryString).HasMaxLength(4000);

                entity.Property(e => e.Urlfull)
                    .HasMaxLength(4000)
                    .HasColumnName("URLFull");
            });

            modelBuilder.Entity<MembershipPermission>(entity =>
            {
                entity.ToTable("MembershipPermission");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(4000);

                entity.Property(e => e.FullName).HasMaxLength(4000);

                entity.Property(e => e.Hour).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.IndustryCompareId).HasColumnName("IndustryCompareID");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.IsAdHoc).HasColumnName("IsAd_hoc");

                entity.Property(e => e.IsBiWeekly).HasColumnName("IsBi_weekly");

                entity.Property(e => e.IsHalfYear).HasColumnName("IsHalf_year");

                entity.Property(e => e.IsNegativeAlert).HasColumnName("IsNegative_alert");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.Minute).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Phone).HasMaxLength(4000);

                entity.Property(e => e.ProductCompareId).HasColumnName("ProductCompareID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(4000);

                entity.Property(e => e.ReportTypeId).HasColumnName("ReportTypeID");

                entity.Property(e => e.Second).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.ServicesFormatId).HasColumnName("ServicesFormatID");

                entity.Property(e => e.ServicesId).HasColumnName("ServicesID");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.Id, "ProductID");

                entity.HasIndex(e => e.Id, "ProductIndex")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "idx_lastname");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArticleTypeId).HasColumnName("ArticleTypeID");

                entity.Property(e => e.AssessId).HasColumnName("AssessID");

                entity.Property(e => e.Author).HasMaxLength(4000);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DatePublish).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasMaxLength(4000);

                entity.Property(e => e.FileName).HasMaxLength(4000);

                entity.Property(e => e.FullName).HasMaxLength(4000);

                entity.Property(e => e.Guicode)
                    .HasMaxLength(4000)
                    .HasColumnName("GUICode");

                entity.Property(e => e.Image).HasMaxLength(4000);

                entity.Property(e => e.ImageThumbnail).HasMaxLength(4000);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Media).HasMaxLength(4000);

                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");

                entity.Property(e => e.MetaDescription).HasMaxLength(4000);

                entity.Property(e => e.MetaKeyword).HasMaxLength(4000);

                entity.Property(e => e.MetaTitle).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Page).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PriceUnitId).HasColumnName("PriceUnitID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReportMonthlyId).HasColumnName("ReportMonthlyID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.Source).HasMaxLength(4000);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.Tags).HasMaxLength(4000);

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.TitleEnglish).HasMaxLength(4000);

                entity.Property(e => e.TitleProperty).HasMaxLength(4000);

                entity.Property(e => e.Urlcode)
                    .HasMaxLength(4000)
                    .HasColumnName("URLCode");
            });

            modelBuilder.Entity<ProductMonthly>(entity =>
            {
                entity.ToTable("Product_Monthly");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArticleTypeId).HasColumnName("ArticleTypeID");

                entity.Property(e => e.AssessId).HasColumnName("AssessID");

                entity.Property(e => e.Author).HasMaxLength(4000);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DatePublish).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasMaxLength(4000);

                entity.Property(e => e.FileName).HasMaxLength(4000);

                entity.Property(e => e.FullName).HasMaxLength(4000);

                entity.Property(e => e.Guicode)
                    .HasMaxLength(4000)
                    .HasColumnName("GUICode");

                entity.Property(e => e.Image).HasMaxLength(4000);

                entity.Property(e => e.ImageThumbnail).HasMaxLength(4000);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Media).HasMaxLength(4000);

                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");

                entity.Property(e => e.MetaDescription).HasMaxLength(4000);

                entity.Property(e => e.MetaKeyword).HasMaxLength(4000);

                entity.Property(e => e.MetaTitle).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Page).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PriceUnitId).HasColumnName("PriceUnitID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReportMonthlyId).HasColumnName("ReportMonthlyID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.Source).HasMaxLength(4000);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.Tags).HasMaxLength(4000);

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.TitleEnglish).HasMaxLength(4000);

                entity.Property(e => e.TitleProperty).HasMaxLength(4000);

                entity.Property(e => e.Urlcode)
                    .HasMaxLength(4000)
                    .HasColumnName("URLCode");
            });

            modelBuilder.Entity<ProductPermission>(entity =>
            {
                entity.ToTable("ProductPermission");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.DateBegin).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<ProductProperty>(entity =>
            {
                entity.ToTable("ProductProperty");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Advalue).HasColumnType("money");

                entity.Property(e => e.ArticleTypeId).HasColumnName("ArticleTypeID");

                entity.Property(e => e.AssessId).HasColumnName("AssessID");

                entity.Property(e => e.BottleCanDesignValue)
                    .HasColumnType("money")
                    .HasColumnName("Bottle_CanDesignValue");

                entity.Property(e => e.CampaignKeyMessage).HasMaxLength(4000);

                entity.Property(e => e.CampaignName).HasMaxLength(4000);

                entity.Property(e => e.CategoryMain).HasMaxLength(4000);

                entity.Property(e => e.CategoryMainId).HasColumnName("CategoryMainID");

                entity.Property(e => e.CategorySub).HasMaxLength(4000);

                entity.Property(e => e.CategorySubId).HasColumnName("CategorySubID");

                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName).HasMaxLength(4000);

                entity.Property(e => e.CompetitiveNewsValue).HasColumnType("money");

                entity.Property(e => e.CompetitiveWhat).HasMaxLength(4000);

                entity.Property(e => e.CorpCopy).HasMaxLength(4000);

                entity.Property(e => e.CorpCopyId).HasColumnName("CorpCopyID");

                entity.Property(e => e.DateAnalysis).HasColumnType("datetime");

                entity.Property(e => e.DateCoding).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDailyDownload).HasColumnType("datetime");

                entity.Property(e => e.DatePublish).HasColumnType("datetime");

                entity.Property(e => e.DateReport).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Day).HasMaxLength(4000);

                entity.Property(e => e.Duration).HasMaxLength(4000);

                entity.Property(e => e.FeatureCorp).HasMaxLength(4000);

                entity.Property(e => e.FeatureCorpId).HasColumnName("FeatureCorpID");

                entity.Property(e => e.FeatureProduct).HasMaxLength(4000);

                entity.Property(e => e.FeatureProductId).HasColumnName("FeatureProductID");

                entity.Property(e => e.FeatureValue).HasColumnType("money");

                entity.Property(e => e.FileName).HasMaxLength(4000);

                entity.Property(e => e.FullName).HasMaxLength(4000);

                entity.Property(e => e.GoodForHealthValue).HasColumnType("money");

                entity.Property(e => e.Guicode)
                    .HasMaxLength(4000)
                    .HasColumnName("GUICode");

                entity.Property(e => e.Headline).HasMaxLength(4000);

                entity.Property(e => e.HeadlineEngLish).HasMaxLength(4000);

                entity.Property(e => e.HeadlineValue).HasColumnType("money");

                entity.Property(e => e.Industry).HasMaxLength(4000);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.IssueNumber)
                    .HasMaxLength(4000)
                    .HasColumnName("Issue_Number");

                entity.Property(e => e.Journalist).HasMaxLength(4000);

                entity.Property(e => e.KeyMessage).HasMaxLength(4000);

                entity.Property(e => e.Kolvalue)
                    .HasColumnType("money")
                    .HasColumnName("KOLValue");

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.MediaTitle).HasMaxLength(4000);

                entity.Property(e => e.MediaType).HasMaxLength(4000);

                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");

                entity.Property(e => e.Month).HasMaxLength(4000);

                entity.Property(e => e.Mps)
                    .HasColumnType("money")
                    .HasColumnName("MPS");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.NutritionFactValue).HasColumnType("money");

                entity.Property(e => e.OtherValue).HasColumnType("money");

                entity.Property(e => e.Page).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.PictureValue).HasColumnType("money");

                entity.Property(e => e.Point).HasColumnType("money");

                entity.Property(e => e.PriceValue).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductNameProjectName)
                    .HasMaxLength(4000)
                    .HasColumnName("ProductName_ProjectName");

                entity.Property(e => e.Quarter).HasMaxLength(4000);

                entity.Property(e => e.ReportMonthlyId).HasColumnName("ReportMonthlyID");

                entity.Property(e => e.RomeCorpUsd)
                    .HasColumnType("money")
                    .HasColumnName("ROME_Corp_USD");

                entity.Property(e => e.RomeCorpVnd)
                    .HasColumnType("money")
                    .HasColumnName("ROME_Corp_VND");

                entity.Property(e => e.RomeProductUsd)
                    .HasColumnType("money")
                    .HasColumnName("ROME_Product_USD");

                entity.Property(e => e.RomeProductVnd)
                    .HasColumnType("money")
                    .HasColumnName("ROME_Product_VND");

                entity.Property(e => e.Segment).HasMaxLength(4000);

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.SegmentProduct).HasMaxLength(4000);

                entity.Property(e => e.SegmentProductId).HasColumnName("SegmentProductID");

                entity.Property(e => e.SentimentCorp).HasMaxLength(4000);

                entity.Property(e => e.SentimentCorpId).HasColumnName("SentimentCorpID");

                entity.Property(e => e.SentimentProduct).HasMaxLength(4000);

                entity.Property(e => e.SentimentProductId).HasColumnName("SentimentProductID");

                entity.Property(e => e.SentimentValue).HasColumnType("money");

                entity.Property(e => e.Soecompany)
                    .HasColumnType("money")
                    .HasColumnName("SOECompany");

                entity.Property(e => e.Soeproduct)
                    .HasColumnType("money")
                    .HasColumnName("SOEProduct");

                entity.Property(e => e.SourceCode).HasMaxLength(4000);

                entity.Property(e => e.SpokePersonName).HasMaxLength(4000);

                entity.Property(e => e.SpokePersonTitle).HasMaxLength(4000);

                entity.Property(e => e.SpokePersonValue).HasColumnType("money");

                entity.Property(e => e.TasteValue).HasColumnType("money");

                entity.Property(e => e.TierCommsights).HasMaxLength(4000);

                entity.Property(e => e.TierCommsightsId).HasColumnName("TierCommsightsID");

                entity.Property(e => e.TierCustomer).HasMaxLength(4000);

                entity.Property(e => e.TierCustomerId).HasColumnName("TierCustomerID");

                entity.Property(e => e.TierValue).HasColumnType("money");

                entity.Property(e => e.TitleProperty).HasMaxLength(4000);

                entity.Property(e => e.ToneValue).HasColumnType("money");

                entity.Property(e => e.Url)
                    .HasMaxLength(4000)
                    .HasColumnName("URL");

                entity.Property(e => e.VitaminValue).HasColumnType("money");

                entity.Property(e => e.Week).HasMaxLength(4000);

                entity.Property(e => e.Year).HasMaxLength(4000);
            });

            modelBuilder.Entity<ProductPropertyMonthly>(entity =>
            {
                entity.ToTable("ProductProperty_Monthly");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Advalue).HasColumnType("money");

                entity.Property(e => e.ArticleTypeId).HasColumnName("ArticleTypeID");

                entity.Property(e => e.AssessId).HasColumnName("AssessID");

                entity.Property(e => e.BottleCanDesignValue)
                    .HasColumnType("money")
                    .HasColumnName("Bottle_CanDesignValue");

                entity.Property(e => e.CampaignKeyMessage).HasMaxLength(4000);

                entity.Property(e => e.CampaignName).HasMaxLength(4000);

                entity.Property(e => e.CategoryMain).HasMaxLength(4000);

                entity.Property(e => e.CategoryMainId).HasColumnName("CategoryMainID");

                entity.Property(e => e.CategorySub).HasMaxLength(4000);

                entity.Property(e => e.CategorySubId).HasColumnName("CategorySubID");

                entity.Property(e => e.Code).HasMaxLength(4000);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CompanyName).HasMaxLength(4000);

                entity.Property(e => e.CompetitiveNewsValue).HasColumnType("money");

                entity.Property(e => e.CompetitiveWhat).HasMaxLength(4000);

                entity.Property(e => e.CorpCopy).HasMaxLength(4000);

                entity.Property(e => e.CorpCopyId).HasColumnName("CorpCopyID");

                entity.Property(e => e.DateAnalysis).HasColumnType("datetime");

                entity.Property(e => e.DateCoding).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateDailyDownload).HasColumnType("datetime");

                entity.Property(e => e.DatePublish).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Day).HasMaxLength(4000);

                entity.Property(e => e.Duration).HasMaxLength(4000);

                entity.Property(e => e.FeatureCorp).HasMaxLength(4000);

                entity.Property(e => e.FeatureCorpId).HasColumnName("FeatureCorpID");

                entity.Property(e => e.FeatureProduct).HasMaxLength(4000);

                entity.Property(e => e.FeatureProductId).HasColumnName("FeatureProductID");

                entity.Property(e => e.FeatureValue).HasColumnType("money");

                entity.Property(e => e.FileName).HasMaxLength(4000);

                entity.Property(e => e.FullName).HasMaxLength(4000);

                entity.Property(e => e.GoodForHealthValue).HasColumnType("money");

                entity.Property(e => e.Guicode)
                    .HasMaxLength(4000)
                    .HasColumnName("GUICode");

                entity.Property(e => e.Headline).HasMaxLength(4000);

                entity.Property(e => e.HeadlineEngLish).HasMaxLength(4000);

                entity.Property(e => e.HeadlineValue).HasColumnType("money");

                entity.Property(e => e.Industry).HasMaxLength(4000);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.IssueNumber)
                    .HasMaxLength(4000)
                    .HasColumnName("Issue_Number");

                entity.Property(e => e.Journalist).HasMaxLength(4000);

                entity.Property(e => e.KeyMessage).HasMaxLength(4000);

                entity.Property(e => e.Kolvalue)
                    .HasColumnType("money")
                    .HasColumnName("KOLValue");

                entity.Property(e => e.MediaTitle).HasMaxLength(4000);

                entity.Property(e => e.MediaType).HasMaxLength(4000);

                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");

                entity.Property(e => e.Month).HasMaxLength(4000);

                entity.Property(e => e.Mps)
                    .HasColumnType("money")
                    .HasColumnName("MPS");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.NutritionFactValue).HasColumnType("money");

                entity.Property(e => e.OtherValue).HasColumnType("money");

                entity.Property(e => e.Page).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.PictureValue).HasColumnType("money");

                entity.Property(e => e.Point).HasColumnType("money");

                entity.Property(e => e.PriceValue).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductNameProjectName)
                    .HasMaxLength(4000)
                    .HasColumnName("ProductName_ProjectName");

                entity.Property(e => e.Quarter).HasMaxLength(4000);

                entity.Property(e => e.ReportMonthlyId).HasColumnName("ReportMonthlyID");

                entity.Property(e => e.RomeCorpUsd)
                    .HasColumnType("money")
                    .HasColumnName("ROME_Corp_USD");

                entity.Property(e => e.RomeCorpVnd)
                    .HasColumnType("money")
                    .HasColumnName("ROME_Corp_VND");

                entity.Property(e => e.RomeProductUsd)
                    .HasColumnType("money")
                    .HasColumnName("ROME_Product_USD");

                entity.Property(e => e.RomeProductVnd)
                    .HasColumnType("money")
                    .HasColumnName("ROME_Product_VND");

                entity.Property(e => e.Segment).HasMaxLength(4000);

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.SegmentProduct).HasMaxLength(4000);

                entity.Property(e => e.SegmentProductId).HasColumnName("SegmentProductID");

                entity.Property(e => e.SentimentCorp).HasMaxLength(4000);

                entity.Property(e => e.SentimentCorpId).HasColumnName("SentimentCorpID");

                entity.Property(e => e.SentimentProduct).HasMaxLength(4000);

                entity.Property(e => e.SentimentProductId).HasColumnName("SentimentProductID");

                entity.Property(e => e.SentimentValue).HasColumnType("money");

                entity.Property(e => e.Soecompany)
                    .HasColumnType("money")
                    .HasColumnName("SOECompany");

                entity.Property(e => e.Soeproduct)
                    .HasColumnType("money")
                    .HasColumnName("SOEProduct");

                entity.Property(e => e.SourceCode).HasMaxLength(4000);

                entity.Property(e => e.SpokePersonName).HasMaxLength(4000);

                entity.Property(e => e.SpokePersonTitle).HasMaxLength(4000);

                entity.Property(e => e.SpokePersonValue).HasColumnType("money");

                entity.Property(e => e.TasteValue).HasColumnType("money");

                entity.Property(e => e.TierCommsights).HasMaxLength(4000);

                entity.Property(e => e.TierCommsightsId).HasColumnName("TierCommsightsID");

                entity.Property(e => e.TierCustomer).HasMaxLength(4000);

                entity.Property(e => e.TierCustomerId).HasColumnName("TierCustomerID");

                entity.Property(e => e.TierValue).HasColumnType("money");

                entity.Property(e => e.TitleProperty).HasMaxLength(4000);

                entity.Property(e => e.ToneValue).HasColumnType("money");

                entity.Property(e => e.Url)
                    .HasMaxLength(4000)
                    .HasColumnName("URL");

                entity.Property(e => e.VitaminValue).HasColumnType("money");

                entity.Property(e => e.Week).HasMaxLength(4000);

                entity.Property(e => e.Year).HasMaxLength(4000);
            });

            modelBuilder.Entity<ProductSearch>(entity =>
            {
                entity.ToTable("ProductSearch");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DatePublishBegin).HasColumnType("datetime");

                entity.Property(e => e.DatePublishEnd).HasColumnType("datetime");

                entity.Property(e => e.DateSearch).HasColumnType("datetime");

                entity.Property(e => e.DateSend).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.HourString).HasMaxLength(50);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ReportFormat)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SearchString).HasMaxLength(4000);

                entity.Property(e => e.Summary).HasMaxLength(4000);

                entity.Property(e => e.Title).HasMaxLength(4000);
            });

            modelBuilder.Entity<ProductSearchProperty>(entity =>
            {
                entity.ToTable("ProductSearchProperty");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArticleTypeId).HasColumnName("ArticleTypeID");

                entity.Property(e => e.AssessId).HasColumnName("AssessID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DatePublishBegin).HasColumnType("datetime");

                entity.Property(e => e.DatePublishEnd).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Point).HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductId001).HasColumnName("ProductID001");

                entity.Property(e => e.ProductPropertyId).HasColumnName("ProductPropertyID");

                entity.Property(e => e.ProductSearchId).HasColumnName("ProductSearchID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.Summary).HasMaxLength(4000);
            });

            modelBuilder.Entity<ProductTest>(entity =>
            {
                entity.ToTable("Product_Test");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArticleTypeId).HasColumnName("ArticleTypeID");

                entity.Property(e => e.AssessId).HasColumnName("AssessID");

                entity.Property(e => e.Author).HasMaxLength(4000);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DatePublish).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Duration).HasMaxLength(4000);

                entity.Property(e => e.FileName).HasMaxLength(4000);

                entity.Property(e => e.FullName).HasMaxLength(4000);

                entity.Property(e => e.Guicode)
                    .HasMaxLength(4000)
                    .HasColumnName("GUICode");

                entity.Property(e => e.Image).HasMaxLength(4000);

                entity.Property(e => e.ImageThumbnail).HasMaxLength(4000);

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Media).HasMaxLength(4000);

                entity.Property(e => e.MembershipId).HasColumnName("MembershipID");

                entity.Property(e => e.MetaDescription).HasMaxLength(4000);

                entity.Property(e => e.MetaKeyword).HasMaxLength(4000);

                entity.Property(e => e.MetaTitle).HasMaxLength(4000);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Page).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PriceUnitId).HasColumnName("PriceUnitID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ReportMonthlyId).HasColumnName("ReportMonthlyID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.Source).HasMaxLength(4000);

                entity.Property(e => e.SourceId).HasColumnName("SourceID");

                entity.Property(e => e.Tags).HasMaxLength(4000);

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.Property(e => e.Title).HasMaxLength(4000);

                entity.Property(e => e.TitleEnglish).HasMaxLength(4000);

                entity.Property(e => e.TitleProperty).HasMaxLength(4000);

                entity.Property(e => e.Urlcode)
                    .HasMaxLength(4000)
                    .HasColumnName("URLCode");
            });

            modelBuilder.Entity<ReportMonthly>(entity =>
            {
                entity.ToTable("ReportMonthly");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.IndustryId).HasColumnName("IndustryID");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title).HasMaxLength(4000);
            });

            modelBuilder.Entity<ReportMonthlyProperty>(entity =>
            {
                entity.ToTable("ReportMonthlyProperty");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductPropertyId).HasColumnName("ProductPropertyID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
