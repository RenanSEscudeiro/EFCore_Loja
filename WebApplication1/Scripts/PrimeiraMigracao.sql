IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Pedidos] (
    [Id] uniqueidentifier NOT NULL,
    [status] nvarchar(max) NULL,
    [OrderDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Preco] real NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PedidosItems] (
    [Id] uniqueidentifier NOT NULL,
    [IdPedido] uniqueidentifier NOT NULL,
    [IdProduto] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PedidosItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PedidosItems_Pedidos_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PedidosItems_Produtos_IdProduto] FOREIGN KEY ([IdProduto]) REFERENCES [Produtos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PedidosItems_IdPedido] ON [PedidosItems] ([IdPedido]);

GO

CREATE INDEX [IX_PedidosItems_IdProduto] ON [PedidosItems] ([IdProduto]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200908192317_InitialCrate', N'3.1.8');

GO

ALTER TABLE [PedidosItens] ADD [Quantidade] int NOT NULL DEFAULT 0;

GO

