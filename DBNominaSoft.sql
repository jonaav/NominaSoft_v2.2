CREATE DATABASE DBNominaSoft

USE [DBNominaSoft]
GO

CREATE TABLE Afp(
	[idAfp] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](70) NOT NULL,
	[porcentajeDescuento] [decimal](4, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idAfp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BoletaPago]    Script Date: 28/11/2019 -UTSILAB418- 08:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoletaPago](
	[idBoletaPago] [int] IDENTITY(1,1) NOT NULL,
	[asignacionFamiliar] [decimal](6, 2) NOT NULL,
	[fecha] [date] NOT NULL,
	[totalHoras] [decimal](18, 0) NOT NULL,
	[valorHoras] [decimal](4, 2) NOT NULL,
	[idContrato] [int] NOT NULL,
	[idPeriodoPago] [int] NOT NULL,
	[idConceptosDePago] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idBoletaPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConceptosDePago]    Script Date: 28/11/2019 -UTSILAB418- 08:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConceptosDePago](
	[idConceptosDePago] [int] IDENTITY(1,1) NOT NULL,
	[montoHorasAusente] [decimal](8, 2) NOT NULL,
	[montoHorasExtra] [decimal](8, 2) NOT NULL,
	[montoReintegros] [decimal](8, 2) NOT NULL,
	[otrosDescuentos] [decimal](8, 2) NOT NULL,
	[otrosIngresos] [decimal](8, 2) NOT NULL,
	[totalAdelantos] [decimal](8, 2) NOT NULL,
	[idContrato] [int] NOT NULL,
	[idPeriodoPago] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idConceptosDePago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 28/11/2019 -UTSILAB418- 08:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Contrato](
	[idContrato] [int] IDENTITY(1,1) NOT NULL,
	[asignacionFamiliar] [bit] NOT NULL,
	[cargo] [varchar](15) NOT NULL,
	[estado] [int] NOT NULL,
	[fechaInicio] [date] NOT NULL,
	[fechaFin] [date] NOT NULL,
	[horasSemanales] [int] NOT NULL,
	[idAfp] [int] NOT NULL,
	[idEmpleado] [int] NOT NULL,
	[valorHora] [decimal](4, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idContrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 28/11/2019 -UTSILAB418- 08:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[dni] [char](8) NOT NULL,
	[nombre] [varchar](45) NOT NULL,
	[direccion] [varchar](40) NULL,
	[telefono] [varchar](9) NOT NULL,
	[estadoCivil] [varchar](10) NOT NULL,
	[gradoAcademico] [varchar](15) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PeriodoPago]    Script Date: 28/11/2019 -UTSILAB418- 08:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeriodoPago](
	[idPeriodoPago] [int] IDENTITY(1,1) NOT NULL,
	[fechaInicio] [date] NOT NULL,
	[fechaFin] [date] NOT NULL,
	[estado] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPeriodoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BoletaPago]  WITH CHECK ADD  CONSTRAINT [FK_BoletaPago_ConceptosDePago] FOREIGN KEY([idConceptosDePago])
REFERENCES [dbo].[ConceptosDePago] ([idConceptosDePago])
GO
ALTER TABLE [dbo].[BoletaPago] CHECK CONSTRAINT [FK_BoletaPago_ConceptosDePago]
GO
ALTER TABLE [dbo].[BoletaPago]  WITH CHECK ADD  CONSTRAINT [FK_BoletaPago_Contrato] FOREIGN KEY([idContrato])
REFERENCES [dbo].[Contrato] ([idContrato])
GO
ALTER TABLE [dbo].[BoletaPago] CHECK CONSTRAINT [FK_BoletaPago_Contrato]
GO
ALTER TABLE [dbo].[BoletaPago]  WITH CHECK ADD  CONSTRAINT [FK_BoletaPago_PeriodoPago] FOREIGN KEY([idPeriodoPago])
REFERENCES [dbo].[PeriodoPago] ([idPeriodoPago])
GO
ALTER TABLE [dbo].[BoletaPago] CHECK CONSTRAINT [FK_BoletaPago_PeriodoPago]
GO
ALTER TABLE [dbo].[ConceptosDePago]  WITH CHECK ADD  CONSTRAINT [FK_conceptosdepago_contrato] FOREIGN KEY([idContrato])
REFERENCES [dbo].[Contrato] ([idContrato])
GO
ALTER TABLE [dbo].[ConceptosDePago] CHECK CONSTRAINT [FK_conceptosdepago_contrato]
GO
ALTER TABLE [dbo].[ConceptosDePago]  WITH CHECK ADD  CONSTRAINT [FK_conceptosdepago_periodoPago] FOREIGN KEY([idPeriodoPago])
REFERENCES [dbo].[PeriodoPago] ([idPeriodoPago])
GO
ALTER TABLE [dbo].[ConceptosDePago] CHECK CONSTRAINT [FK_conceptosdepago_periodoPago]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD FOREIGN KEY([idAfp])
REFERENCES [dbo].[Afp] ([idAfp])
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO

insert into AFP values('prima',15)
insert into AFP values('integra',12)

insert into Empleado values('18056723','Juan Carlos','calle34','123123123','soltero','profesional','1998-02-18')
insert into Empleado values('48271151','Jorge','calle35','123123222','soltero','bachiller','1995-12-10')
insert into Empleado values('75395128','Yahaira','calle33','123123444','casado','magister','1998-08-17')
insert into Empleado values('28931745','Rocio','calle18','236874159','casado','doctor','1997-05-03')
insert into Empleado values('34534532','Pepe','calle63','123123444','casado','doctor','1999-10-23')
insert into Empleado values('75523527','Alfonso','calle21','044468443','soltero','magister','1987-04-18')
insert into Empleado values('79626072','Eduardo','calle27','957114018','casado','bachiller','1992-11-30')


insert into Contrato values(1,'Gerente',1,'2019-06-30','2020-03-20','40',1,1,25)
insert into Contrato values(1,'Jefe',1,'2019-06-05','2020-03-30','23',1,2,16)
insert into Contrato values(1,'Administrador',1,'2019-07-05','2020-02-12','15',1,3,31)
insert into Contrato values(1,'Jefe',1,'2019-07-04','2020-02-03','40',1,4,25)
insert into Contrato values(1,'Gerente',1,'2019-08-02','2020-06-09','25',1,5,50)
insert into Contrato values(1,'Administrador',1,'2019-09-12','2020-03-17','10',1,6,40)
insert into Contrato values(0,'Administrador',1,'2019-10-02','2020-02-12','10',1,7,15)



insert into PeriodoPago values('2019-11-01','2019-11-15',1)
insert into PeriodoPago values('2019-11-16','2019-11-30',1)

insert into ConceptosDePago values(0,150,210,20,100,120,1,1)
insert into ConceptosDePago values(0,100,200,0,120,100,2,1)
insert into ConceptosDePago values(30,140,150,80,50,80,3,1)
insert into ConceptosDePago values(50,300,230,0,0,130,4,1)
insert into ConceptosDePago values(0,0,0,0,0,0,5,1)
insert into ConceptosDePago values(30,300,200,50,120,100,6,1)
insert into ConceptosDePago values(20,250,200,0,120,0,7,1)
