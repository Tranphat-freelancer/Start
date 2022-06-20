# Start
Cách chạy project : 
Bước đầu tiên: Cấu hình connection string trong file appsetting.json ở DbMigrator Project, Main.Web, Main.Host, TinhThanh.Host, QuanHuyen.Host
B2: Chạy Project DbMigrator
B3: Set StartUp Project TinhThanh.Host rồi mở Package Manager Console chọn Default Project là TinhThanh.EntityFramework Core sau đó gõ lệnh vào console: update-database
B4: Set StartUp Project QuanHuyen.Host rồi mở Package Manager Console chọn Default Project là QuanHuyen.EntityFramework Core sau đó gõ lệnh vào console: update-database
B5: Chạy Multi Project Main.Web, Main.Identity, Main.Host, TinhThanh.Host,QuanHuyen.Host
