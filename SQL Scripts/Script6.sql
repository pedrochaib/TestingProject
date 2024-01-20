select CountryCode, count(CountryCode) as 'Number of cities'
from City
group by CountryCode
having count(CountryCode) > 2;