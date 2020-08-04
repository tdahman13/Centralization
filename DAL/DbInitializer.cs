using Centralization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centralization.DAL
{
    public class DbInitializer
    {
        public static void Initialize(MemorialContext context)
        {
            //context.Database.EnsureCreated();

            if (context.MemorialApplications.Any())
            {
                return;     // DB has been seeded
            }

            var memorialApplications = new MemorialApplication[]
            {
                new MemorialApplication
                {
                    FileName="dupiq00w.prs",
                    FilePath=@"\ALL SAINTS\05-All Saints\OptionalCompleteService\2020\",
                    Type=(ApplicationType)0,
                    UploadDate=DateTime.Parse("8/4/2020 8:22:43 AM"),
                    UploadedBy="Test",
                    CemNo="05"
                },
                new MemorialApplication
                {
                    FileName="wdkclso1.eix",
                    FilePath=@"\ALL SAINTS\05-All Saints\CompleteCemeteryService\2020\",
                    Type=(ApplicationType)1,
                    UploadDate=DateTime.Parse("8/4/2020 8:23:17 AM"),
                    UploadedBy="test2",
                    CemNo="05"
                },
                new MemorialApplication
                {
                    FileName="azcxvsj3.m5z",
                    FilePath=@"\ALL SAINTS\05-All Saints\OptionalCompleteService\2020\",
                    Type=(ApplicationType)0,
                    UploadDate=DateTime.Parse("8/4/2020 8:38:00 AM"),
                    UploadedBy="test3",
                    CemNo="05"
                },
                new MemorialApplication
                {
                    FileName="0cft1l5r.wca",
                    FilePath=@"\ALL SAINTS\05-All Saints\OptionalCompleteService\2020\",
                    Type=(ApplicationType)2,
                    UploadDate=DateTime.Parse("8/4/2020 8:38:42 AM"),
                    UploadedBy="test4",
                    CemNo="05"
                },
                new MemorialApplication
                {
                    FileName="ttjkjpbu.rsu",
                    FilePath=@"\GOOD SHEPHERD\49-SS. Cyril & Methodius, Lemont\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("8/4/2020 8:40:14 AM"),
                    UploadedBy="test5",
                    CemNo="49"
                },
                new MemorialApplication
                {
                    FileName="2q51kmpw.u1e",
                    FilePath=@"\MARYHILL\42-Maryhill\OptionalCompleteService\2020\",
                    Type=(ApplicationType)0,
                    UploadDate=DateTime.Parse("8/4/2020 8:55:15 AM"),
                    UploadedBy="test6",
                    CemNo="42"
                },
                new MemorialApplication
                {
                    FileName="2ftoc3l3.gdp",
                    FilePath=@"\SAINT CASIMIR\02-Mount Olivet\OptionalCompleteService\2020\",
                    Type=(ApplicationType)1,
                    UploadDate=DateTime.Parse("8/4/2020 8:55:50 AM"),
                    UploadedBy="test7",
                    CemNo="02"
                },
                new MemorialApplication
                {
                    FileName="1tctgc3h.u30",
                    FilePath=@"\SAINT MICHAEL\34-St. Michael\OptionalCompleteService\2020\",
                    Type=(ApplicationType)0,
                    UploadDate=DateTime.Parse("8/4/2020 8:56:35 AM"),
                    UploadedBy="test8",
                    CemNo="34"
                },
                new MemorialApplication
                {
                    FileName="h00zhv3r.pyr",
                    FilePath=@"\QUEEN OF HEAVEN\03-Mount Carmel\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("8/4/2020 8:57:16 AM"),
                    UploadedBy="test9",
                    CemNo="03"
                },
                new MemorialApplication
                {
                    FileName="2ulyoshz.lht",
                    FilePath=@"\ASCENSION\18-Transfiguration, Wauconda\CompleteCemeteryService\2020\",
                    Type=(ApplicationType)2,
                    UploadDate=DateTime.Parse("8/4/2020 8:59:24 AM"),
                    UploadedBy="test 10",
                    CemNo="18"
                }
            };

            context.MemorialApplications.AddRange(memorialApplications);
            context.SaveChanges();

            var linked = new LinkedInterment[]
            {
                new LinkedInterment{Idf=54355,CemNo="05", MemorialApplicationID = 1},
                new LinkedInterment{Idf=18403,CemNo="05", MemorialApplicationID = 2},
                new LinkedInterment{Idf=96816,CemNo="05", MemorialApplicationID = 3},
                new LinkedInterment{Idf=157822,CemNo="05", MemorialApplicationID = 4},
                new LinkedInterment{Idf=22879,CemNo="05", MemorialApplicationID = 4},
                new LinkedInterment{Idf=395889,CemNo="49", MemorialApplicationID = 5},
                new LinkedInterment{Idf=54020,CemNo="42", MemorialApplicationID = 6},
                new LinkedInterment{Idf=11144,CemNo="02", MemorialApplicationID = 7},
                new LinkedInterment{Idf=13076,CemNo="34", MemorialApplicationID = 8},
                new LinkedInterment{Idf=192383,CemNo="03", MemorialApplicationID = 9},
                new LinkedInterment{Idf=181099,CemNo="03", MemorialApplicationID = 9},
                new LinkedInterment{Idf=34843,CemNo="18", MemorialApplicationID = 10},
                new LinkedInterment{Idf=34831,CemNo="18", MemorialApplicationID = 10},
                new LinkedInterment{Idf=35094,CemNo="18", MemorialApplicationID = 10}
            };

            context.LinkedInterments.AddRange(linked);
            context.SaveChanges();
        }
    }
}
