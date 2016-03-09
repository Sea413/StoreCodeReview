# _A spectacular and fabulous Store App!_

#### _Organize all the Stores!, 2/19/2015_

#### By _**Sean "Boomer" Peerenboom**_

## Description

_The App will match stylists with clients.

## Setup/Installation Requirements

* _Since this site requires for a program to be running, without direct access to the code it will be difficult to run on your own, until our firm looks into private hosting_

_No server maintenance required(that we know of)_

## Known Bugs

_If you type in the communist manifesto, the nothing special will happen. :( One day the proletariat shall overthrow the bourgeoisie so we still have hope though!)._

## Support and contact details

_For support contact the NSA at
Acquisition Resource Center (ARC)
Phone: (410) 694-0750
Fax: (410) 694-0773
E-mail: nsaarc@nsaarc.net
(Ask for Phil)

Community Relations:
The Office of State, Local & Community Relations
Phone: (301) 688-1818
E-mail: DE_Team@nsa.gov_
(He is a cool guy!)

## SQL Table Set Up
In SQLCMD:
CREATE DATABASE shoes_stores;
GO
USE stores_brands;
GO
CREATE TABLE stores (id INT IDENTITY(1,1), name VARCHAR(255));
GO
CREATE TABLE brands (id INT IDENTITY(1,1), name VARCHAR(255), styleid int);
GO
CREATE TABLE stores_brands (id INT Identity (1,1), store_id int, brand_id int)
GO

## Technologies Used

_The programs used are Csharp, HTML, Nancy, mysql, and Razor.

### License

*This application has been filed and registered with StarFleet Enterprise and is pending approval of the Galactic Federation of Ricks.*

Copyright (c) 2015 **_Boomer Inc_**
