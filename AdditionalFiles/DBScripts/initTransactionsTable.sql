--start app firstly, in order to users and icons tables be seeded;
--secondly, init transaction statuses and types;
--feel free to execute current script.

INSERT INTO public."Transactions" ("Name", "Amount", "Description", "Date", "IconId", "OwnerId", "AuthorizedUserId", "StatusId", "TypeTitle")
VALUES
    ('Transaction 1', 100.00, 'First transaction', NOW(), NULL, 1, NULL, 1, 'Payment'),
    ('Transaction 2', 50.00, 'Second transaction', NOW(), 1, 1, 3, NULL, 'Credit'),
    ('Transaction 3', 75.00, 'Third transaction', NOW(), NULL, 2, 1, NULL, 'Payment'),
    ('Transaction 4', 25.00, 'Fourth transaction', NOW(), 1, 2, NULL, NULL, 'Credit'),
    ('Transaction 5', 125.00, 'Fifth transaction', NOW(), 1, 2, NULL, 1, 'Payment'),
	('Transaction 6', 145.00, 'Sixth transaction', NOW(), NULL, 2, NULL, NULL, 'Payment'),
	('Transaction 7', 105.00, 'Seventh transaction', NOW(), 2, 2, NULL, NULL, 'Credit'),
	('Transaction 8', 10.00, 'Eight transaction', NOW(), 2, 2, NULL, NULL, 'Credit'),
	('Transaction 9', 100.00, 'Nineth transaction', NOW(), 1, 3, NULL, 1, 'Payment'),
	('Transaction 10', 175.00, 'Ten transaction', NOW(), NULL, 3, NULL, NULL, 'Payment'),
	('Transaction 11', 55.00, 'Eleven transaction', NOW(), NULL, 3, NULL, NULL, 'Payment'),
	('Transaction 12', 40.00, 'Twelve transaction', NOW(), 1, 3, NULL, NULL, 'Credit'),
	('Transaction 13', 90.00, 'Thirteen transaction', NOW(), 1, 3, 1, NULL, 'Payment'),
	('Transaction 14', 15.00, 'Fourteen transaction', NOW(), 1, 3, 1, NULL, 'Credit'),
	('Transaction 15', 120.00, 'Fifteen transaction', NOW(), 1, 3, NULL, NULL, 'Payment'),
	('Transaction 16', 300.00, 'Sixteen transaction', NOW(), 1, 3, NULL, NULL, 'Payment'),
	('Transaction 17', 100.00, 'Seventeen transaction', NOW(), NULL, 3, NULL, NULL, 'Credit'),
	('Transaction 18', 190.00, 'Eighteen transaction', NOW(), 2, 3, 2, NULL, 'Credit'),
	('Transaction 19', 80.00, 'Nineteen transaction', NOW(), NULL, 3, NULL, NULL, 'Payment'),
	('Transaction 20', 75.00, 'Twenty transaction', NOW(), 2, 3, 2, NULL, 'Payment'),
	('Transaction 21', 210.00, 'Twenty-first transaction', NOW(), 1, 3, NULL, NULL, 'Payment');
