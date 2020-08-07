/* 1.Count the number of rows in each of the tables in the IN database.*/

    SELECT COUNT(*) AS "passengers"
        FROM passengers_IN;
    
    SELECT COUNT(*) AS "flights"
        FROM flights;
    
    SELECT COUNT(*) AS "reservation"
        FROM reservation; 

    SELECT COUNT(*) AS "reservation_detials"
        FROM reservation_details;
    
/* 2. Create a copy of passengers_IN table and call it Passengers_copy 
but only select passengers who live in texas or new york. */
    CREATE TABLE Passengers_copy
        AS SELECT *
            FROM passengers_IN
            WHERE passenger_state = 'TX' OR passenger_state = 'NY'; 

/* 3. Using a column list, add passenger to Passengers_copy. 
The passenger does not have a fax number.
Make the addition permanent.*/
    INSERT INTO Passengers_copy (passenger_id, passenger_first_name, passenger_last_name, 
        passenger_address, passenger_city, passenger_state, passenger_zip, passenger_phone, passenger_fax)
        VALUES ('143','Joe','Appleseed','123 Avenue Street','Dallas','TX','73323','1239484839', NULL);
        
    COMMIT;

/* 4. Update Joe phone number to 938-573-2934. */
    UPDATE Passengers_copy
        SET passenger_phone = '9385732934'
        WHERE passenger_id = '143';  
        
    COMMIT;
    
/* 5. Delete Susie Appleseed from new york, new york from Passengers_copy */
    DELETE Passengers_copy
        WHERE passenger_first_name = 'Susie' AND passenger_last_name = 'Appleseed'
            AND passenger_city = 'New York' AND passenger_state = 'NY';

/* 6. Undo the delete in 5*/
    rollback;
    
/* 7. Create a read only view called Passengers_copy_v and contains all passengers 
except those who live in IO. */
    CREATE VIEW Passengers_copy_v AS
        SELECT *
            FROM Passengers_copy
            WHERE passenger_state != 'IO'
        WITH READ ONLY;
        
/* 8. Create another view that has the following columns: 
passenger ID, reservation ID, passenger first name, passenger last name, city, state, 
reservation date, reservation_qty, ticket ID, and unit price. 
Rename four of the columns to “FirstN”, “LastN”, “City”, “State”. 
Use the keyword that will allow users to create the view multiple times without having to drop it. */
    CREATE OR REPLACE VIEW passenger_reservation_tickets_v (passenger_id, reservation_id, "FirstN", "LastN", 
    "City", "State", reservation_date, reservation_qty, ticket_id, unit_price) AS
        SELECT p.passenger_id, r.reservation_id, passenger_first_name, passenger_last_name, passenger_city, 
        passenger_state, reservation_date, reservation_qty, f.ticket_id, title, artist, unit_price
            FROM Passengers_copy P
            JOIN reservations R
            ON p.passenger_id = r.passenger_id
            JOIN reservation_details RD
            ON r.reservation_id = rd.reservation_id
            JOIN tickets f
            ON RD.ticket_id = f.ticket_id;

/* 9. Write a SQL statement to retrieve first name, last name, city, reservation date, 
title, and unit price of passenger ‘Kimberly Twain’ from CUSTOMER_RESERVATION_FLIGHTS_V. */
    SELECT "FirstN", "LastN", "City", reservation_date, title, unit_price
        FROM passenger_reservation_tickets_v
        WHERE artist = 'Kimberly Twain';
        
/* 10. Write another SQL statement from the view to output summary information of 
passenger state, passenger city, and sales (quantity multiplied by price) 
for Tenessee, Virginia, and Washington. */
    SELECT "State", "City", SUM(reservation_qty*unit_price) AS "Sales"
        FROM passenger_reservation_tickets_v
        WHERE "State" = 'TN' OR "State" = 'VA' OR "State" = 'WA' 
        GROUP BY "State", "City";