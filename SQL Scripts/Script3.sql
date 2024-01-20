select sum(p.Population) as 'Total Population', count(c.CountryCode) as 'Amount of Cities', c.CountryCode
from Population p
inner join City c on p.CityId = c.Id
Group BY c.CountryCode;