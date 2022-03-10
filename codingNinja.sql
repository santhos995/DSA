--https://www.codingninjas.com/codestudio/problems/managers-with-at-least-5-direct-reports_2119330?topList=top-100-sql-problems&leftPanelTab=0
select
    m.name
from
    employee e,
    employee m
where
    e.managerId = m.Id
group by
    m.name
having
    count(m.name) > 4;

--https://www.codingninjas.com/codestudio/problems/winning-candidate_2119331?topList=top-100-sql-problems&leftPanelTab=0
Solution 1:
select
    Name
from
    candidate
where
    id = (
        select
            v.candidateId
        from
            candidate c,
            vote v
        where
            v.CandidateId = c.Id
        group by
            (v.candidateId)
        order by
            count(v.candidateId) desc
        limit
            1
    );

Solution 2:
select
    c.Name as "Name"
from
    candidate c,
    vote v
where
    v.CandidateId = c.Id
group by
    (c.Name)
order by
    count(c.Name) desc
limit
    1;

--https://www.codingninjas.com/codestudio/problems/percentage-of-users-attended-a-contest_2188791?topList=top-100-sql-problems&leftPanelTab=1
select
    contest_id,
    round(
        (
            count(contest_id) :: NUMERIC /(
                select
                    count(user_id)
                from
                    Users
            ) :: NUMERIC
        ) * 100,
        2
    ) as "percentage"
from
    register
group by
    contest_id
order by
    percentage desc,
    contest_id;

--https://www.codingninjas.com/codestudio/problems/warehouse-manager_2181185?topList=top-100-sql-problems&leftPanelTab=0
select name as "warehouse_name",
sum(units * (Width*Length*Height)) as "volume"
from Warehouse w, Products p
where w.product_id = p.product_id group by name;

--https://www.codingninjas.com/codestudio/problems/top-travellers_2117112?topList=top-100-sql-problems&leftPanelTab=1
select name, COALESCE(sum(distance),0) as "travelled_distance"
from Users u left join rides r
on r.user_id = u.id group by name 
order by travelled_distance desc, name;