USE [master]
GO
/****** Object:  Database [FitnessStudioDB]    Script Date: 23-Jul-25 00:10:33 ******/
CREATE DATABASE [FitnessStudioDB]

GO
ALTER DATABASE [FitnessStudioDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FitnessStudioDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FitnessStudioDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FitnessStudioDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FitnessStudioDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FitnessStudioDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FitnessStudioDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FitnessStudioDB] SET  MULTI_USER 
GO
ALTER DATABASE [FitnessStudioDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FitnessStudioDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FitnessStudioDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FitnessStudioDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FitnessStudioDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FitnessStudioDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FitnessStudioDB] SET QUERY_STORE = OFF
GO
USE [FitnessStudioDB]
GO
/****** Object:  Table [dbo].[Clan]    Script Date: 23-Jul-25 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clan](
	[IdClana] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](60) NOT NULL,
	[Prezime] [varchar](60) NOT NULL,
	[Email] [varchar](60) NOT NULL,
	[brTel] [varchar](11) NOT NULL,
	[IdKat] [int] NOT NULL,
 CONSTRAINT [PK_Clan] PRIMARY KEY CLUSTERED 
(
	[IdClana] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrupniProgram]    Script Date: 23-Jul-25 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GrupniProgram](
	[IdGrPr] [int] IDENTITY(1,1) NOT NULL,
	[NazivGrPr] [varchar](50) NOT NULL,
	[OpisGrPr] [varchar](1000) NOT NULL,
	[CenaTermina] [float] NOT NULL,
 CONSTRAINT [PK_GrupniProgram] PRIMARY KEY CLUSTERED 
(
	[IdGrPr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategorija]    Script Date: 23-Jul-25 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorija](
	[IdKategorije] [int] IDENTITY(1,1) NOT NULL,
	[NazivKat] [varchar](60) NOT NULL,
	[OpisKat] [varchar](120) NOT NULL,
	[Popust] [float] NOT NULL,
 CONSTRAINT [PK_Kategorija] PRIMARY KEY CLUSTERED 
(
	[IdKategorije] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odlazak]    Script Date: 23-Jul-25 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odlazak](
	[id_clana] [int] NOT NULL,
	[datumOdlaska] [date] NOT NULL,
	[id_grpr] [int] NOT NULL,
	[Placeno] [bit] NOT NULL,
 CONSTRAINT [PK_Odlazak] PRIMARY KEY CLUSTERED 
(
	[id_clana] ASC,
	[datumOdlaska] ASC,
	[id_grpr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operater]    Script Date: 23-Jul-25 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operater](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](50) NOT NULL,
	[Prezime] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Lozinka] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Operater] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Racun]    Script Date: 23-Jul-25 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Racun](
	[redniBRac] [int] IDENTITY(1,1) NOT NULL,
	[mesec] [int] NOT NULL,
	[godina] [int] NOT NULL,
	[iznos] [float] NOT NULL,
	[id_cl] [int] NOT NULL,
 CONSTRAINT [PK_Racun] PRIMARY KEY CLUSTERED 
(
	[redniBRac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clan] ON 

INSERT [dbo].[Clan] ([IdClana], [Ime], [Prezime], [Email], [brTel], [IdKat]) VALUES (2, N'Andjela', N'Stankovic', N'andjela@gmail.com', N'0694004177', 2)
INSERT [dbo].[Clan] ([IdClana], [Ime], [Prezime], [Email], [brTel], [IdKat]) VALUES (3, N'Stefan', N'Milosevic', N'stefan@gmail.com', N'068524436', 2)
INSERT [dbo].[Clan] ([IdClana], [Ime], [Prezime], [Email], [brTel], [IdKat]) VALUES (5, N'Nana', N'Nanic', N'nana@gm.com', N'0649876543', 3)
INSERT [dbo].[Clan] ([IdClana], [Ime], [Prezime], [Email], [brTel], [IdKat]) VALUES (8, N'Sofija', N'Stojiljkovic', N'sofija1@gmail.com', N'0692483597', 1)
INSERT [dbo].[Clan] ([IdClana], [Ime], [Prezime], [Email], [brTel], [IdKat]) VALUES (1006, N'Sanja', N'Simic', N'sanjaNoviMejl@gmail.com', N'0655436436', 5)
INSERT [dbo].[Clan] ([IdClana], [Ime], [Prezime], [Email], [brTel], [IdKat]) VALUES (1007, N'Ivana', N'Avramovic', N'ivanaavramovic13@gmail.com', N'06723456', 1)
INSERT [dbo].[Clan] ([IdClana], [Ime], [Prezime], [Email], [brTel], [IdKat]) VALUES (1008, N'Dragan', N'Bogdanovic', N'dragaaaboo@yahoo.com', N'061112222', 3)
INSERT [dbo].[Clan] ([IdClana], [Ime], [Prezime], [Email], [brTel], [IdKat]) VALUES (2009, N'Georgije', N'Simic', N'georg@gmail.com', N'067345702', 3)
SET IDENTITY_INSERT [dbo].[Clan] OFF
GO
SET IDENTITY_INSERT [dbo].[GrupniProgram] ON 

INSERT [dbo].[GrupniProgram] ([IdGrPr], [NazivGrPr], [OpisGrPr], [CenaTermina]) VALUES (1, N'Pilates', N'Fokusirajte se na jacanje misica, poboljsanje fleksibilnosti i razvijanje svesti o telu kroz kontrolisane pokrete i disanje. Osnovni principi pilatesa ukljucuju centriranje, koncentraciju, kontrolu, preciznost, disanje i fluidnost pokreta.', 200)
INSERT [dbo].[GrupniProgram] ([IdGrPr], [NazivGrPr], [OpisGrPr], [CenaTermina]) VALUES (2, N'Full body workout', N'Trening svih grupa misica i kardio intenzivno sagorevaju kalorije i masti. Povecava se kondicija, snaga i oblikuje telo.', 300)
INSERT [dbo].[GrupniProgram] ([IdGrPr], [NazivGrPr], [OpisGrPr], [CenaTermina]) VALUES (3, N'Zumba', N'Zumba je u plesu, zabavi i muzici ali je takode i veoma pažljivo kreiran trening. Svaki pokret i promena ritma osmisljeni su tako da steknes vrhunski izgled, formu i zdravlje. ', 270)
INSERT [dbo].[GrupniProgram] ([IdGrPr], [NazivGrPr], [OpisGrPr], [CenaTermina]) VALUES (4, N'Bodycombat', N'Ovaj poseban spoj stabilnog stanja i visokog intenziteta povecava izdrzljivost i kondiciju, i dovodi do sagorevanja kalorija koje je usko povezano sa intervalnim vezbanjem visokog intenziteta.', 250)
INSERT [dbo].[GrupniProgram] ([IdGrPr], [NazivGrPr], [OpisGrPr], [CenaTermina]) VALUES (5, N'Yoga', N'Usmerena je na upostavljanje harmonije uma, tela i duha, odnosno postizanje stanja opustenosti, srece i pozitivne energije.', 260)
SET IDENTITY_INSERT [dbo].[GrupniProgram] OFF
GO
SET IDENTITY_INSERT [dbo].[Kategorija] ON 

INSERT [dbo].[Kategorija] ([IdKategorije], [NazivKat], [OpisKat], [Popust]) VALUES (1, N'Student', N'Osoba koja pohadja fakultet i ima ispod 29 godina.', 10)
INSERT [dbo].[Kategorija] ([IdKategorije], [NazivKat], [OpisKat], [Popust]) VALUES (2, N'Employed', N'Osoba u stalnom radnom odnosu i ima preko 26 godina.', 5)
INSERT [dbo].[Kategorija] ([IdKategorije], [NazivKat], [OpisKat], [Popust]) VALUES (3, N'Retired', N'Osoba preko 65 godina.', 15)
INSERT [dbo].[Kategorija] ([IdKategorije], [NazivKat], [OpisKat], [Popust]) VALUES (4, N'Child', N'Osoba ispod 12 godina.', 15)
INSERT [dbo].[Kategorija] ([IdKategorije], [NazivKat], [OpisKat], [Popust]) VALUES (5, N'None', N'Ne pripada ni jednoj kategoriji.', 0)
SET IDENTITY_INSERT [dbo].[Kategorija] OFF
GO
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1006, CAST(N'2025-07-14' AS Date), 2, 0)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2023-02-01' AS Date), 3, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2023-02-12' AS Date), 1, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2023-02-15' AS Date), 5, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2023-02-21' AS Date), 4, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2023-07-03' AS Date), 4, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2023-07-14' AS Date), 5, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2024-02-01' AS Date), 2, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2024-02-02' AS Date), 2, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2024-02-03' AS Date), 4, 0)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2024-02-03' AS Date), 5, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2024-02-06' AS Date), 1, 0)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2024-02-07' AS Date), 4, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2024-02-12' AS Date), 4, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1007, CAST(N'2024-02-17' AS Date), 3, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1008, CAST(N'2025-06-03' AS Date), 1, 0)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (1008, CAST(N'2025-06-12' AS Date), 3, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (2009, CAST(N'2024-02-01' AS Date), 2, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (2009, CAST(N'2024-02-02' AS Date), 3, 0)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (2009, CAST(N'2024-02-05' AS Date), 2, 1)
INSERT [dbo].[Odlazak] ([id_clana], [datumOdlaska], [id_grpr], [Placeno]) VALUES (2009, CAST(N'2025-07-13' AS Date), 5, 1)
GO
SET IDENTITY_INSERT [dbo].[Operater] ON 

INSERT [dbo].[Operater] ([Id], [Ime], [Prezime], [Email], [Lozinka]) VALUES (1, N'Marija', N'Savic', N'marijasavic1991@gmail.com', N'EA5E7040DCFB37491A1C165D3EEF4BB9A88321EFEB8B739BE386C0ABC7F16288')
INSERT [dbo].[Operater] ([Id], [Ime], [Prezime], [Email], [Lozinka]) VALUES (2, N'Dragan', N'Djordjevic', N'dragandjo123@yahoo.com', N'09645A4A3ED9671B4BDAD57B9AEE89EC41050B3D03D2344DD454F40CF54D230E')
INSERT [dbo].[Operater] ([Id], [Ime], [Prezime], [Email], [Lozinka]) VALUES (3, N'Nikola', N'Petrovic', N'nindza89@gmail.com', N'9EADDC6CED04A60F5077D65BEC9D415FE78E59E6D114E98CE1A56412006B42BA')
INSERT [dbo].[Operater] ([Id], [Ime], [Prezime], [Email], [Lozinka]) VALUES (4, N'Andjela', N'Stankovic', N'a', N'043A718774C572BD8A25ADBEB1BFCD5C0256AE11CECF9F9C3F925D0E52BEAF89')
SET IDENTITY_INSERT [dbo].[Operater] OFF
GO
SET IDENTITY_INSERT [dbo].[Racun] ON 

INSERT [dbo].[Racun] ([redniBRac], [mesec], [godina], [iznos], [id_cl]) VALUES (1, 2, 2024, 405, 1007)
INSERT [dbo].[Racun] ([redniBRac], [mesec], [godina], [iznos], [id_cl]) VALUES (2, 2, 2023, 0, 1007)
INSERT [dbo].[Racun] ([redniBRac], [mesec], [godina], [iznos], [id_cl]) VALUES (3, 7, 2023, 0, 1007)
INSERT [dbo].[Racun] ([redniBRac], [mesec], [godina], [iznos], [id_cl]) VALUES (4, 2, 2024, 229.5, 2009)
INSERT [dbo].[Racun] ([redniBRac], [mesec], [godina], [iznos], [id_cl]) VALUES (1004, 6, 2025, 170, 1008)
INSERT [dbo].[Racun] ([redniBRac], [mesec], [godina], [iznos], [id_cl]) VALUES (2004, 7, 2025, 0, 5)
INSERT [dbo].[Racun] ([redniBRac], [mesec], [godina], [iznos], [id_cl]) VALUES (3004, 7, 2025, 0, 2009)
INSERT [dbo].[Racun] ([redniBRac], [mesec], [godina], [iznos], [id_cl]) VALUES (3005, 7, 2025, 300, 1006)
SET IDENTITY_INSERT [dbo].[Racun] OFF
GO
ALTER TABLE [dbo].[Clan]  WITH CHECK ADD  CONSTRAINT [FK_Clan_Kategorija] FOREIGN KEY([IdKat])
REFERENCES [dbo].[Kategorija] ([IdKategorije])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Clan] CHECK CONSTRAINT [FK_Clan_Kategorija]
GO
ALTER TABLE [dbo].[Odlazak]  WITH CHECK ADD  CONSTRAINT [FK_Odlazak_Clan] FOREIGN KEY([id_clana])
REFERENCES [dbo].[Clan] ([IdClana])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Odlazak] CHECK CONSTRAINT [FK_Odlazak_Clan]
GO
ALTER TABLE [dbo].[Odlazak]  WITH CHECK ADD  CONSTRAINT [FK_Odlazak_GrupniProgram] FOREIGN KEY([id_grpr])
REFERENCES [dbo].[GrupniProgram] ([IdGrPr])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Odlazak] CHECK CONSTRAINT [FK_Odlazak_GrupniProgram]
GO
ALTER TABLE [dbo].[Racun]  WITH CHECK ADD  CONSTRAINT [FK_Racun_Clan] FOREIGN KEY([id_cl])
REFERENCES [dbo].[Clan] ([IdClana])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Racun] CHECK CONSTRAINT [FK_Racun_Clan]
GO
USE [master]
GO
ALTER DATABASE [FitnessStudioDB] SET  READ_WRITE 
GO
