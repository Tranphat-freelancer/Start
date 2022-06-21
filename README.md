# Start  </br></br>
Chuyển sang nhánh TTQH, mở Main.sln Project TTQH </br></br>
Cách chạy project :  </br></br>
B1: Cấu hình connection string trong file appsetting.json ở DbMigrator Project, Main.Web, Main.Host, TinhThanh.Host, QuanHuyen.Host </br> </br>
B2: Chạy Project DbMigrator </br></br>
B3: Set StartUp Project TinhThanh.Host rồi mở Package Manager Console chọn Default Project là TinhThanh.EntityFramework Core sau đó gõ lệnh vào console: update-database </br></br>
B4: Set StartUp Project QuanHuyen.Host rồi mở Package Manager Console chọn Default Project là QuanHuyen.EntityFramework Core sau đó gõ lệnh vào console: update-database </br></br>
B5: Chạy Multi Project Main.Web, Main.Identity, Main.Host, TinhThanh.Host,QuanHuyen.Host
