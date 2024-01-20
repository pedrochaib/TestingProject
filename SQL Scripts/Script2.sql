select top 1 c.Name from City c
inner join Population p on c.Id = p.CityId
where c.CountryCode = 'CN' order by Population asc;