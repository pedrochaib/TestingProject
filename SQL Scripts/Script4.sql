select top 3 c.Name, p.Population
from City c
inner join Population p on c.Id = p.CityId
order by Population desc;