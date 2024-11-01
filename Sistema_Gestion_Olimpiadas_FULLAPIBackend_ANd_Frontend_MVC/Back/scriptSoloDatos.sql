USE [Obligatorio_Olimpiadas]
GO
SET IDENTITY_INSERT [dbo].[Delegados] ON 

INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (1, N'Juan Pérez', 1234567890)
INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (2, N'María González', 987654321)
INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (3, N'Carlos Ramírez', 1122334455)
INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (4, N'Ana Torres', 55667788)
INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (5, N'José Rodríguez', 66778899)
INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (6, N'Laura Fernández', 77889900)
INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (7, N'Miguel Gutiérrez', 88990011)
INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (8, N'Sofía Martínez', 99001122)
INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (9, N'Pedro Gómez', 1010101010)
INSERT [dbo].[Delegados] ([Id], [Nombre], [Telefono]) VALUES (10, N'Lucía Herrera', 2020202020)
SET IDENTITY_INSERT [dbo].[Delegados] OFF
GO
SET IDENTITY_INSERT [dbo].[Paises] ON 

INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (1, N'Estados Unidos', 331002651, 1)
INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (2, N'España', 47351567, 2)
INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (3, N'Alemania', 83166711, 3)
INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (4, N'Japón', 126476461, 4)
INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (5, N'Francia', 65273511, 5)
INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (6, N'China', 1439323776, 6)
INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (7, N'Rusia', 145912025, 7)
INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (8, N'Emiratos Árabes Unidos', 9890402, 8)
INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (9, N'Brasil', 212559417, 9)
INSERT [dbo].[Paises] ([Id], [Nombre], [CantidadHabitantes], [DelegadoId]) VALUES (10, N'Egipto', 102334404, 10)
SET IDENTITY_INSERT [dbo].[Paises] OFF
GO
SET IDENTITY_INSERT [dbo].[Disciplinas] ON 

INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (1, N'Natación Olimpica', 1896)
INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (2, N'Atletismo Olimpico', 1896)
INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (3, N'Gimnasia Olimpica', 1896)
INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (4, N'Fútbol Olimpico', 1900)
INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (5, N'Tenis Olimpico', 1896)
INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (6, N'Baloncesto Olimpico', 1936)
INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (7, N'Voleibol Olimpico', 1964)
INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (8, N'Boxeo Olimpico', 1904)
INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (9, N'Ciclismo Olimpico', 1896)
INSERT [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioDisciplina_Valor]) VALUES (10, N'Judo Olimpico', 1964)
SET IDENTITY_INSERT [dbo].[Disciplinas] OFF
GO
SET IDENTITY_INSERT [dbo].[Eventos] ON 

INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (1, N'100m Masculino Final', 2, CAST(N'2024-07-30T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-30T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (2, N'200m Femenino Final', 2, CAST(N'2024-07-31T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-31T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (3, N'Salto Largo Masculino', 2, CAST(N'2024-08-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (4, N'Final de Gimnasia Artística', 3, CAST(N'2024-08-02T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (5, N'Final de Judo', 10, CAST(N'2024-08-03T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (6, N'Final de Natación 100m Libre', 1, CAST(N'2024-07-28T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (7, N'Final de Fútbol Masculino', 4, CAST(N'2024-08-10T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (8, N'Final de Tenis Femenino', 5, CAST(N'2024-08-11T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (9, N'Maratón Masculino', 2, CAST(N'2024-08-12T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Eventos] ([Id], [NombreEvento_Valor], [DisciplinaId], [FechaInicio], [FechaFinal]) VALUES (10, N'Final de Boxeo Peso Pesado', 8, CAST(N'2024-08-13T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-13T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Eventos] OFF
GO
SET IDENTITY_INSERT [dbo].[Atletas] ON 

INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (1, N'Michael', N'Phelps', 1, 1)
INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (2, N'Usain', N'Bolt', 1, 9)
INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (3, N'Simone', N'Biles', 0, 1)
INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (4, N'Rafael', N'Nadal', 1, 3)
INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (5, N'Serena', N'Williams', 0, 1)
INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (6, N'Yao', N'Ming', 1, 6)
INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (7, N'Neymar', N'Junior', 1, 9)
INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (8, N'Maria', N'Sharapova', 0, 7)
INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (9, N'Didier', N'Drogba', 1, 10)
INSERT [dbo].[Atletas] ([Id], [Nombre], [Apellido], [EsMasculino], [PaisId]) VALUES (10, N'Naomi', N'Osaka', 0, 5)
SET IDENTITY_INSERT [dbo].[Atletas] OFF
GO
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (1, 1)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (3, 1)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (7, 1)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (10, 1)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (1, 2)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (2, 2)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (6, 2)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (9, 2)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (2, 3)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (4, 3)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (7, 3)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (10, 3)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (3, 4)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (5, 4)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (9, 4)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (1, 5)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (4, 5)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (8, 5)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (3, 6)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (5, 6)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (8, 6)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (2, 7)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (6, 7)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (10, 7)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (4, 8)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (9, 8)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (5, 9)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (7, 9)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (6, 10)
INSERT [dbo].[AtletaDisciplina] ([AtletasId], [DisciplinasId]) VALUES (8, 10)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Nombre]) VALUES (1, N'Administrador')
INSERT [dbo].[Roles] ([Id], [Nombre]) VALUES (2, N'Digitador')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (1, N'maria.gomez@comiteolimpico.org', N'Inicio1234.!', 1, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (2, N'juan.perez@comiteolimpico.org', N'Inicio1234.!', 1, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (3, N'ana.lopez@comiteolimpico.org', N'Inicio1234.!', 1, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (4, N'carlos.martinez@comiteolimpico.org', N'Inicio1234.!', 2, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (5, N'laura.garcia@comiteolimpico.org', N'Inicio1234.!', 2, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (6, N'pedro.fernandez@comiteolimpico.org', N'Inicio1234.!', 2, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (7, N'sofia.rodriguez@comiteolimpico.org', N'Inicio1234.!', 2, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (8, N'david.sanchez@comiteolimpico.org', N'Inicio1234.!', 2, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (9, N'carolina.diaz@comiteolimpico.org', N'Inicio1234.!', 2, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
INSERT [dbo].[Usuarios] ([Id], [Email_Valor], [Contrasenia_Valor], [RolId], [Date], [Hour], [EmailAdmin]) VALUES (10, N'alejandro.ramirez@comiteolimpico.org', N'Inicio1234.!', 2, N'Oct 17 2024 12:16PM', N'Oct 17 2024 12:16PM', N'admin@comiteolimpico.org')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[EventoAtleta] ON 

INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (1, 1, 1, CAST(85.50 AS Decimal(18, 2)))
INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (2, 1, 2, CAST(90.20 AS Decimal(18, 2)))
INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (3, 2, 1, CAST(78.30 AS Decimal(18, 2)))
INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (4, 2, 3, CAST(88.10 AS Decimal(18, 2)))
INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (5, 3, 2, CAST(92.70 AS Decimal(18, 2)))
INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (6, 4, 1, CAST(75.00 AS Decimal(18, 2)))
INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (7, 5, 3, CAST(80.50 AS Decimal(18, 2)))
INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (8, 6, 2, CAST(95.40 AS Decimal(18, 2)))
INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (9, 7, 1, CAST(70.90 AS Decimal(18, 2)))
INSERT [dbo].[EventoAtleta] ([Id], [AtletaId], [EventoId], [PuntajeAtleta]) VALUES (10, 8, 2, CAST(89.60 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[EventoAtleta] OFF
GO
