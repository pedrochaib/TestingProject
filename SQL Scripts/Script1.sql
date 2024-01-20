select c.Name from City c
left join Population p on c.Id = p.CityId
where p.Population < 130000 and c.CountryCode = 'USA';