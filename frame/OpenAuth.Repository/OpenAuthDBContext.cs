﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OpenAuth.Repository.Domain;
using OpenAuth.Repository.Mapping;

namespace OpenAuth.Repository
{
    public partial class OpenAuthDBContext: DbContext
    {
        static  OpenAuthDBContext()
        {
            Database.SetInitializer< OpenAuthDBContext>(null);
        }

        public OpenAuthDBContext()
            : base("Name=OpenAuthDBContext")
        {
            // 关闭语义可空判断
            Configuration.UseDatabaseNullSemantics = true;

            //与变量的值为null比较
            //ef判断为null的时候，不能用变量比较：https://stackoverflow.com/questions/682429/how-can-i-query-for-null-values-in-entity-framework?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
            (this as IObjectContextAdapter).ObjectContext.ContextOptions.UseCSharpNullComparisonBehavior = true;
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public OpenAuthDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        public System.Data.Entity.DbSet<Application> Applications { get; set; }
        public System.Data.Entity.DbSet<Category> Categories { get; set; }
        public System.Data.Entity.DbSet<CategoryType> CategoryTypes { get; set; }
        public System.Data.Entity.DbSet<Module> Modules { get; set; }
        public System.Data.Entity.DbSet<ModuleElement> ModuleElements { get; set; }
        public System.Data.Entity.DbSet<Org> Orgs { get; set; }
        public System.Data.Entity.DbSet<Relevance> Relevances { get; set; }
        public System.Data.Entity.DbSet<Resource> Resources { get; set; }
        public System.Data.Entity.DbSet<Role> Roles { get; set; }
        public System.Data.Entity.DbSet<Stock> Stocks { get; set; }
        public System.Data.Entity.DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Form> Forms { get; set; }

        public System.Data.Entity.DbSet<FlowInstance> FlowInstances { get; set; }
        public System.Data.Entity.DbSet<FlowInstanceOperationHistory> FlowInstanceOperationHistories { get; set; }
        public System.Data.Entity.DbSet<FlowInstanceTransitionHistory> FlowInstanceTransitionHistories { get; set; }
        public System.Data.Entity.DbSet<FlowScheme> FlowSchemes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CategoryTypeMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new ModuleElementMap());
            modelBuilder.Configurations.Add(new OrgMap());
            modelBuilder.Configurations.Add(new RelevanceMap());
            modelBuilder.Configurations.Add(new ResourceMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new StockMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new FormMap());
            modelBuilder.Configurations.Add(new FlowInstanceMap());
            modelBuilder.Configurations.Add(new FlowInstanceOperationHistoryMap());
            modelBuilder.Configurations.Add(new FlowInstanceTransitionHistoryMap());
            modelBuilder.Configurations.Add(new FlowSchemeMap());

            modelBuilder.Configurations.Add(new T_QsMainLogMap());

            modelBuilder.Configurations.Add(new T_QsDetailLog1Map());

            modelBuilder.Configurations.Add(new T_QsDetailLog2Map());


            modelBuilder.Configurations.Add(new T_QsDetailLog3Map());

            modelBuilder.Configurations.Add(new T_QsDetailLog4Map());


            modelBuilder.Configurations.Add(new T_QsDetailLog5Map());

            modelBuilder.Configurations.Add(new T_QsDetailLog6Map());


            modelBuilder.Configurations.Add(new T_QsSuggestMap());



        }
    }
}