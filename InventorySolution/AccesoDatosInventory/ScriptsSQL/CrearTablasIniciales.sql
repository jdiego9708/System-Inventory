USE [InventoryBD]
GO
/****** Object:  Table [dbo].[Catalogo]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalogo](
	[Id_tipo] [int] NOT NULL,
	[Id_padre] [int] NOT NULL,
	[Nombre_tipo] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Catalogo] PRIMARY KEY CLUSTERED 
(
	[Id_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credenciales_usuario]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credenciales_usuario](
	[Id_credencial] [int] NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Fecha_credencial] [date] NOT NULL,
	[Hora_credencial] [time](2) NOT NULL,
	[Password] [varchar](500) NOT NULL,
	[Estado_credencial] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Credenciales_usuario] PRIMARY KEY CLUSTERED 
(
	[Id_credencial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_facturacion]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_facturacion](
	[Id_facturacion] [int] NOT NULL,
	[Id_tipo_detalle] [int] NOT NULL,
	[Valor_detalle] [decimal](19, 2) NOT NULL,
	[Observaciones_detalle] [decimal](19, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direcciones_cliente]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direcciones_cliente](
	[Id_direccion] [int] IDENTITY(1,1) NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Referencia_ubicacion] [varchar](200) NULL,
	[Estado_direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Direcciones_cliente] PRIMARY KEY CLUSTERED 
(
	[Id_direccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturacion]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturacion](
	[Id_facturacion] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_facturacion] [date] NOT NULL,
	[Hora_facturacion] [time](2) NOT NULL,
	[Total_facturacion] [decimal](19, 2) NOT NULL,
	[Observaciones] [varchar](200) NULL,
 CONSTRAINT [PK_Facturacion] PRIMARY KEY CLUSTERED 
(
	[Id_facturacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id_movimiento] [int] NOT NULL,
	[Id_tipo_movimiento] [int] NOT NULL,
	[Fecha_movimiento] [date] NOT NULL,
	[Hora_movimiento] [time](2) NOT NULL,
	[Descripcion_movimiento] [varchar](500) NOT NULL,
	[Estado_movimiento] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id_movimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Id_pedido] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_pedido] [date] NOT NULL,
	[Hora_pedido] [time](2) NOT NULL,
	[Id_tipo_pedido] [int] NOT NULL,
	[Id_cliente] [int] NOT NULL,
	[Id_empleado] [int] NOT NULL,
	[Observaciones_pedido] [varchar](50) NULL,
	[CantidadClientes] [int] NULL,
	[NumeroMesa] [int] NULL,
	[Informacion_adicional] [varchar](500) NULL,
	[Estado_pedido] [varchar](50) NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id_pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id_producto] [int] NOT NULL,
	[Id_tipo_producto] [int] NOT NULL,
	[Nombre_producto] [varchar](50) NOT NULL,
	[Precio_producto] [decimal](19, 2) NOT NULL,
	[Imagen_producto] [varchar](max) NOT NULL,
	[Descripcion_producto] [varchar](500) NULL,
	[Estado_producto] [varchar](50) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reglas]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reglas](
	[Id_regla] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_regla] [varchar](50) NOT NULL,
	[Estado_regla] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Reglas] PRIMARY KEY CLUSTERED 
(
	[Id_regla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reglas_usuario]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reglas_usuario](
	[Id_regla_usuario] [int] IDENTITY(1,1) NOT NULL,
	[Id_regla] [int] NOT NULL,
	[Id_usuario] [int] NOT NULL,
	[Estado_regla] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Reglas_usuario] PRIMARY KEY CLUSTERED 
(
	[Id_regla_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[Id_turno] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_inicio_turno] [date] NOT NULL,
	[Hora_fin_turno] [time](2) NOT NULL,
	[Valor_inicial] [decimal](19, 2) NOT NULL,
	[Total_ingresos] [decimal](19, 2) NOT NULL,
	[Total_egresos] [decimal](19, 2) NOT NULL,
	[Total_ventas] [decimal](19, 2) NOT NULL,
	[Total_nomina] [decimal](19, 2) NOT NULL,
	[Total_turno] [decimal](19, 2) NOT NULL,
	[Estado_turno] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Id_turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 5/06/2022 8:41:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id_usuario] [int] NOT NULL,
	[Fecha_ingreso] [date] NOT NULL,
	[Nombre_usuario] [varchar](200) NOT NULL,
	[Telefono_usuario] [varchar](50) NOT NULL,
	[Identificacion_usuario] [varchar](50) NOT NULL,
	[Email_usuario] [varchar](200) NOT NULL,
	[Id_tipo_usuario] [int] NOT NULL,
	[Estado_usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Direcciones_cliente]  WITH CHECK ADD  CONSTRAINT [FK_Direcciones_cliente_Usuarios] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[Usuarios] ([Id_usuario])
GO
ALTER TABLE [dbo].[Direcciones_cliente] CHECK CONSTRAINT [FK_Direcciones_cliente_Usuarios]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Catalogo] FOREIGN KEY([Id_tipo_movimiento])
REFERENCES [dbo].[Catalogo] ([Id_tipo])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Catalogo]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Catalogo] FOREIGN KEY([Id_tipo_pedido])
REFERENCES [dbo].[Catalogo] ([Id_tipo])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Catalogo]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Usuarios] FOREIGN KEY([Id_cliente])
REFERENCES [dbo].[Usuarios] ([Id_usuario])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Usuarios]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Usuarios1] FOREIGN KEY([Id_empleado])
REFERENCES [dbo].[Usuarios] ([Id_usuario])
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Usuarios1]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Catalogo] FOREIGN KEY([Id_tipo_producto])
REFERENCES [dbo].[Catalogo] ([Id_tipo])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Catalogo]
GO
ALTER TABLE [dbo].[Reglas_usuario]  WITH CHECK ADD  CONSTRAINT [FK_Reglas_usuario_Reglas] FOREIGN KEY([Id_regla])
REFERENCES [dbo].[Reglas] ([Id_regla])
GO
ALTER TABLE [dbo].[Reglas_usuario] CHECK CONSTRAINT [FK_Reglas_usuario_Reglas]
GO
ALTER TABLE [dbo].[Reglas_usuario]  WITH CHECK ADD  CONSTRAINT [FK_Reglas_usuario_Usuarios] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[Usuarios] ([Id_usuario])
GO
ALTER TABLE [dbo].[Reglas_usuario] CHECK CONSTRAINT [FK_Reglas_usuario_Usuarios]
GO
