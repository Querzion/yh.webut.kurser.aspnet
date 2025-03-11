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
VALUES ('Hemsida', 'Skapa en hemsida för verksamhet.', '2025-02-28','2025-06-01', 1, 1),
       ('OpenAI', 'Träna AI modell','2025-06-01','2026-06-01',3,1),
       ('Random', 'Random, just Random.', '2025-04-02','2025-06-01', 6, 2);