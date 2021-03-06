USE [bd_innova_school]
GO
/****** Object:  Table [dbo].[tb_Cotizacion]    Script Date: 11/09/2016 4:47:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_Cotizacion](
	[CodCotizacion] [int] IDENTITY(1,1) NOT NULL,
	[FechaCotizacion] [datetime] NULL,
	[CodSolCotizacion] [int] NULL,
	[CodProveedor] [int] NULL,
	[CodEstado] [varchar](1) NULL,
 CONSTRAINT [PK_tb_Cotizacion] PRIMARY KEY CLUSTERED 
(
	[CodCotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_CotizacionDet]    Script Date: 11/09/2016 4:47:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_CotizacionDet](
	[CodCotizacion] [int] NOT NULL,
	[CodArticulo] [int] NOT NULL,
	[Cantidad] [int] NULL,
	[Precio] [decimal](18, 2) NULL,
 CONSTRAINT [PK_CotizacionDet] PRIMARY KEY CLUSTERED 
(
	[CodCotizacion] ASC,
	[CodArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
