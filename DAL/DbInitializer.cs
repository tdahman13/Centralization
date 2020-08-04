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
            context.Database.EnsureCreated();

            if (context.MemorialApplications.Any())
            {
                return;     // DB has been seeded
            }

            var memorialApplications = new MemorialApplication[]
            {
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
                new MemorialApplication
                {
                    FileName="vonbm13q.vz0",
                    FilePath=@"\ALL SAINTS\05-All Saints\NichePlaque\2020\",
                    Type=(ApplicationType)3,
                    UploadDate=DateTime.Parse("7/28/2020 3:26:19 PM"),
                    UploadedBy="Myself",
                    CemNo="07"
                },
            };
        }
    }
}
