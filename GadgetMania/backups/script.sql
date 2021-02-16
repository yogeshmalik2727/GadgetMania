GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a0715118-3f44-4c36-b989-201351fcbd62', N'admin', N'admin', N'2246c256-93a7-4b3e-929d-a055b09e0649')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6f045e1e-2b4a-48b5-bfc2-640a1e6765af', N'admin@gadget.com', N'ADMIN@GADGET.COM', N'admin@gadget.com', N'ADMIN@GADGET.COM', 1, N'AQAAAAEAACcQAAAAEDvWATog7yfgh4vG50fnLZdIEdJQNzoXXeqiVmB3s4m77jJbZn0ulogYnkwiIlYZRw==', N'HJ742SZPIC3YO6VRFUNHOZMBQSBOXO4B', N'b6c2e760-31ef-4071-a194-f05f206be404', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f58fcdbe-0af6-4535-88be-2d99b26317a3', N'user@gmail.com', N'USER@GMAIL.COM', N'user@gmail.com', N'USER@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAENeYn4CdsGBZpIjFoI4CvQuD9So3RrMbN4ayXhQFJJ61Ovjg7wwVrXCxwMtASbqYMQ==', N'5SHI4GKXOD4ANCKTNAN2OY2YJC67VJEG', N'f8a98909-59f2-4dad-afec-04eaaa6c2506', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6f045e1e-2b4a-48b5-bfc2-640a1e6765af', N'a0715118-3f44-4c36-b989-201351fcbd62')
GO
SET IDENTITY_INSERT [dbo].[GadgetManiaCategories] ON 
GO
INSERT [dbo].[GadgetManiaCategories] ([CategoryID], [CategoryName]) VALUES (1, N'Laptop')
GO
INSERT [dbo].[GadgetManiaCategories] ([CategoryID], [CategoryName]) VALUES (2, N'Mobile')
GO
INSERT [dbo].[GadgetManiaCategories] ([CategoryID], [CategoryName]) VALUES (3, N'Digital Camra')
GO
INSERT [dbo].[GadgetManiaCategories] ([CategoryID], [CategoryName]) VALUES (4, N'Head Phone')
GO
SET IDENTITY_INSERT [dbo].[GadgetManiaCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 
GO
INSERT [dbo].[Suppliers] ([SupplierID], [SupplierName], [SupplierAddress], [SupplierContact], [ContactPerson]) VALUES (1, N'Jakson Sales', N'Street:  3532 Smith Avenue  City:  Hamilton', N'905-902-5556', N'Ramson')
GO
INSERT [dbo].[Suppliers] ([SupplierID], [SupplierName], [SupplierAddress], [SupplierContact], [ContactPerson]) VALUES (2, N'Peter  Mobiles', N'Street:  3426  Smith Avenue  City:  Hamilton', N'905-905-1256', N'Peter')
GO
INSERT [dbo].[Suppliers] ([SupplierID], [SupplierName], [SupplierAddress], [SupplierContact], [ContactPerson]) VALUES (3, N'Biden Peripherals ', N'Street:  582 Benton Street  City:  Kitchener  State/province/area:   Ontario', N' 519-404-5549', N'Alex Biden')
GO
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[GadgetManiaProducts] ON 
GO
INSERT [dbo].[GadgetManiaProducts] ([ProductID], [ProductName], [Price], [ProductDescription], [Extension], [CategoryID], [SupplierID]) VALUES (2, N'Dell Inspiron Laptops & 2-in-1 PCs', N'$399.99', N'Configurations
Processor More Info
Intel® Celeron® Processor N4020 (4MB Cache, up to 2.8 GHz)
Operating System More Info
Windows 10 Home (S mode) 64-bit, English
Video Card More Info
Intel® UHD Graphics 600 with shared graphics memory
Memory More Info
4GB, 1x4GB, DDR4, 2400MHz
Hard Drive More Info
128GB M.2 PCIe NVMe Solid State Drive
Display More Info
15.6-inch HD (1366 x 768) Anti-glare LED-Backlit Non-touch Narrow Border Display', N'.jpg', 1, 1)
GO
INSERT [dbo].[GadgetManiaProducts] ([ProductID], [ProductName], [Price], [ProductDescription], [Extension], [CategoryID], [SupplierID]) VALUES (3, N'HP ENVY x360 13-ay0008ca FHD convertible laptop ', N'$1040.99', N'Supported Operating Systems
Operating system: Windows 10 Home 64
Processor:Processor,core 6
cache:8 MB L3
Processor family: AMD Ryzen™ 5 processor
Processor AMD Ryzen™ 5 4500U (2.3 GHz base clock, up to 4.0 GHz max boost clock, 3 MB L2 cache, 6 cores)
Appearance Color : Nightfall black
Product design: Sandblasted anodized finish
Product color: Nightfall black aluminum

Camera Specifications
Webcam	HP Wide Vision HD camera with camera shutter and integrated dual array digital microphone', N'.jpg', 1, 2)
GO
INSERT [dbo].[GadgetManiaProducts] ([ProductID], [ProductName], [Price], [ProductDescription], [Extension], [CategoryID], [SupplierID]) VALUES (4, N'Samsung Galaxy A10S A107M 32GB Unlocked GSM DUOS P', N'$135.00', N'About this item
International Variant/US Compatible LTE
6.2 inch IPS LCD Capacitive Touchscreen, 720 x 1520 pixels Display
Internal Memory: 32GB, 2GB RAM - microSD Up to 512GB
Dual Rear Camera 13 MP (f/1.8, 28mm (wide), AF) & 2 MP (f/2.4, depth sensor), LED Flash, Panorama, HDR & 8 MP Front Facing Camera
Android OS, Mediatek MT6762 Helio P22 , Octa-Core 2.0 GHz Cortex-A53, PowerVR GE8320', N'.jpg', 2, 1)
GO
INSERT [dbo].[GadgetManiaProducts] ([ProductID], [ProductName], [Price], [ProductDescription], [Extension], [CategoryID], [SupplierID]) VALUES (5, N'Samsung Galaxy A10S A107M 32GB Unlocked GSM DUOS P', N'$145.00', N'Wireless Carrier	T-Mobile
Brand	Samsung Electronics
Color	Black
Memory Storage Capacity	32 GB
Operating System	Android
Screen Size	6.2 Inches
Display Type	LCD
Other camera features	Rear, Front
Form Factor	Smartphone
Item Weight	5.92 Ounces', N'.jpg', 2, 1)
GO
INSERT [dbo].[GadgetManiaProducts] ([ProductID], [ProductName], [Price], [ProductDescription], [Extension], [CategoryID], [SupplierID]) VALUES (6, N'Minolta 20 Mega Pixels Wi-Fi Digital Camera with 2', N'$175.00', N'About this item
20 Mega Pixels still image resolution with 1080p HD video resolution
22x optical zoom with optical image stabilization; 8GB SD card included
Wi-Fi & Bluetooth connectivity
Large 3.0 inch LCD screen
Features 29 scene modes, face detection, High Dynamic Range', N'.jpg', 3, 3)
GO
INSERT [dbo].[GadgetManiaProducts] ([ProductID], [ProductName], [Price], [ProductDescription], [Extension], [CategoryID], [SupplierID]) VALUES (7, N'Beat Solo3 Wireless Headphone Solo 3 Bluetooth Hea', N'$50.00', N'Type:	Football
Material:	PVC
Usage:	Racing, Entertainment, Gift
Feature:	Waterproof
Customized:	Customized
Transport Package:	Original Package', N'.jpg', 4, 2)
GO
SET IDENTITY_INSERT [dbo].[GadgetManiaProducts] OFF
GO
