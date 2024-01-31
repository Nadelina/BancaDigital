CREATE TRIGGER TRG_EliminacionCompra ON Compras
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE TitularesTarjeta
    SET SaldoActual = SaldoActual - d.Monto
    FROM TitularesTarjeta tt
    INNER JOIN deleted d ON tt.TitularTarjetaId = d.TitularTarjetaId;
END;
