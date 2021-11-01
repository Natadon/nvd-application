using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nvd.DataAccess.Objects;

namespace Nvd.DataAccess
{
    public class NvdDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)           
            => options.UseSqlServer("Server=Sql01;Database=nvd;User Id=nvd;Password=nvddba;MultipleActiveResultSets=true");
            //=> options.UseSqlite("Data Source=nvd.db");

        public DbSet<RawDownload> RawDownloads { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<References> References { get; set; }

        public DbSet<Reference_Data> Reference_Data { get; set; }

        public DbSet<Problemtype_Data> Problemtype_Data { get; set; }

        public DbSet<Problemtype> ProblemTypes { get; set; }

        public DbSet<NvdSearchResult> NvdSearchResults { get; set; }

        public DbSet<Node> Nodes { get; set; }

        public DbSet<Impact> Impacts { get; set; }

        public DbSet<Description1> Description1 { get; set; }

        public DbSet<Description_Data> Description_Data { get; set; }

        public DbSet<Description> Descriptions { get; set; }

        public DbSet<Cvssv3> Cvssv3s { get; set; }

        public DbSet<Cvssv2> Cvssv2s { get; set; }

        public DbSet<CVE_Items> CVE_Items { get; set; }

        public DbSet<CVE_Data_Meta> CVE_Data_Metas { get; set; }

        public DbSet<Cve> Cves { get; set; }

        public DbSet<Cpe_Match> Cpe_Matches { get; set; }

        public DbSet<Configurations> Configurations { get; set; }

        public DbSet<Basemetricv3> BaseMetricsV3 { get; set; }

        public DbSet<Basemetricv2> BaseMetricsV2 { get; set; }
    }
}
