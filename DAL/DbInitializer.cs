﻿using Centralization.Models;
using System;
using System.Linq;

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

            MemorialApplication[] memorialApplications = {
                new MemorialApplication
                {
                    FileName="dupiq00w.prs",
                    FilePath=@"\ALL SAINTS\05-All Saints\OptionalCompleteService\2020\",
                    Type=0,
                    UploadDate=DateTime.Parse("8/4/2020 8:22:43 AM"),
                    UploadedBy="Seed Data",
                    CemNo="05"
                },
                new MemorialApplication
                {
                    FileName="wdkclso1.eix",
                    FilePath=@"\ALL SAINTS\05-All Saints\CompleteCemeteryService\2020\",
                    Type=(ApplicationType)1,
                    UploadDate=DateTime.Parse("8/4/2020 8:23:17 AM"),
                    UploadedBy="Seed Data",
                    CemNo="05"
                },
                new MemorialApplication
                {
                    FileName="azcxvsj3.m5z",
                    FilePath=@"\ALL SAINTS\05-All Saints\OptionalCompleteService\2020\",
                    Type=(ApplicationType)0,
                    UploadDate=DateTime.Parse("8/4/2020 8:38:00 AM"),
                    UploadedBy="Seed Data",
                    CemNo="05"
                },
                new MemorialApplication
                {
                    FileName="0cft1l5r.wca",
                    FilePath=@"\ALL SAINTS\05-All Saints\OptionalCompleteService\2020\",
                    Type=(ApplicationType)2,
                    UploadDate=DateTime.Parse("8/4/2020 8:38:42 AM"),
                    UploadedBy="Seed Data",
                    CemNo="05"
                },
                new MemorialApplication
                {
                    FileName="ttjkjpbu.rsu",
                    FilePath=@"\GOOD SHEPHERD\49-SS. Cyril & Methodius, Lemont\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("8/4/2020 8:40:14 AM"),
                    UploadedBy="Seed Data",
                    CemNo="49"
                },
                new MemorialApplication
                {
                    FileName="2q51kmpw.u1e",
                    FilePath=@"\MARYHILL\42-Maryhill\OptionalCompleteService\2020\",
                    Type=(ApplicationType)0,
                    UploadDate=DateTime.Parse("8/4/2020 8:55:15 AM"),
                    UploadedBy="Seed Data",
                    CemNo="42"
                },
                new MemorialApplication
                {
                    FileName="2ftoc3l3.gdp",
                    FilePath=@"\SAINT CASIMIR\02-Mount Olivet\OptionalCompleteService\2020\",
                    Type=(ApplicationType)1,
                    UploadDate=DateTime.Parse("8/4/2020 8:55:50 AM"),
                    UploadedBy="Seed Data",
                    CemNo="02"
                },
                new MemorialApplication
                {
                    FileName="1tctgc3h.u30",
                    FilePath=@"\SAINT MICHAEL\34-St. Michael\OptionalCompleteService\2020\",
                    Type=(ApplicationType)0,
                    UploadDate=DateTime.Parse("8/4/2020 8:56:35 AM"),
                    UploadedBy="Seed Data",
                    CemNo="34"
                },
                new MemorialApplication
                {
                    FileName="h00zhv3r.pyr",
                    FilePath=@"\QUEEN OF HEAVEN\03-Mount Carmel\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("8/4/2020 8:57:16 AM"),
                    UploadedBy="Seed Data",
                    CemNo="03"
                },
                new MemorialApplication
                {
                    FileName="2ulyoshz.lht",
                    FilePath=@"\ASCENSION\18-Transfiguration, Wauconda\CompleteCemeteryService\2020\",
                    Type=(ApplicationType)2,
                    UploadDate=DateTime.Parse("8/4/2020 8:59:24 AM"),
                    UploadedBy="Seed Data",
                    CemNo="18"
                }
            };

            context.MemorialApplications.AddRange(memorialApplications);
            context.SaveChanges();

            LinkedInterment[] linked = 
            {
                new LinkedInterment{Idf=54355,CemNo="05", MemorialApplicationId = 1},
                new LinkedInterment{Idf=18403,CemNo="05", MemorialApplicationId = 2},
                new LinkedInterment{Idf=96816,CemNo="05", MemorialApplicationId = 3},
                new LinkedInterment{Idf=157822,CemNo="05", MemorialApplicationId = 4},
                new LinkedInterment{Idf=22879,CemNo="05", MemorialApplicationId = 4},
                new LinkedInterment{Idf=395889,CemNo="49", MemorialApplicationId = 5},
                new LinkedInterment{Idf=54020,CemNo="42", MemorialApplicationId = 6},
                new LinkedInterment{Idf=11144,CemNo="02", MemorialApplicationId = 7},
                new LinkedInterment{Idf=13076,CemNo="34", MemorialApplicationId = 8},
                new LinkedInterment{Idf=192383,CemNo="03", MemorialApplicationId = 9},
                new LinkedInterment{Idf=181099,CemNo="03", MemorialApplicationId = 9},
                new LinkedInterment{Idf=34843,CemNo="18", MemorialApplicationId = 10},
                new LinkedInterment{Idf=34831,CemNo="18", MemorialApplicationId = 10},
                new LinkedInterment{Idf=35094,CemNo="18", MemorialApplicationId = 10}
            };

            context.LinkedInterments.AddRange(linked);
            context.SaveChanges();
        }
    }
}
