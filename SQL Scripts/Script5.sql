select top 1 c.Name
from City c
inner join CarAmount ca on c.Id = ca.CityId
order by ca.Amount desc;