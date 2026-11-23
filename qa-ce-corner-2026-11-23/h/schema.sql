CREATE TABLE qa_ibex_orders (
  id INT PRIMARY KEY,
  total DECIMAL(10,2)
);

CREATE VIEW qa_ibex_big_orders AS
SELECT id, total FROM qa_ibex_orders WHERE total > 100;

CREATE PROCEDURE qa_ibex_archive
AS
BEGIN
  DELETE FROM qa_ibex_orders WHERE total = 0;
END;
