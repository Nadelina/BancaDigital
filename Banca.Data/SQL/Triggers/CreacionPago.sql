CREATE TRIGGER TRG_CreacionPagos ON Pagos
AFTER INSERT
AS
BEGIN
    
    SET NOCOUNT ON;

    UPDATE TitularesTarjeta
    SET SaldoActual = SaldoActual - i.Monto
    FROM TitularesTarjeta tt
    INNER JOIN inserted i ON tt.TitularTarjetaId = i.TitularTarjetaId;
END;
