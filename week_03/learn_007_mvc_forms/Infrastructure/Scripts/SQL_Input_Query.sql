-- SQL Script
-- Created on 11/03/2025 by querzion

-- Write your SQL queries below:
-- SQL Script
-- Created on 10/02/2025 by querzion

-- Write your SQL queries below:

INSERT INTO Statuses (StatusName)
VALUES ('Ej Påbörjad'),
       ('Pågående'),
       ('Avslutat');

INSERT INTO Clients (ClientName)
VALUES ('Querzion Inc.'),
       ('HUG(e)NETWORK Inc.'),
       ('SubstansInformation Org.');

INSERT INTO Projects (Title, Description, StartDate, EndDate, CĺientId, StatusId)
VALUES ('Website', 'Create a website', '2025-06-01','2025-08-26', 1, 1),
       ('OpenAI', 'Train an AI modell','2026-06-01','2028-06-01',3,1)