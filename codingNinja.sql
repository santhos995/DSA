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
select
    name as "warehouse_name",
    sum(units * (Width * Length * Height)) as "volume"
from
    Warehouse w,
    Products p
where
    w.product_id = p.product_id
group by
    name;

--https://www.codingninjas.com/codestudio/problems/top-travellers_2117112?topList=top-100-sql-problems&leftPanelTab=1
select
    name,
    COALESCE(sum(distance), 0) as "travelled_distance"
from
    Users u
    left join rides r on r.user_id = u.id
group by
    name
order by
    travelled_distance desc,
    name;

--https://www.codingninjas.com/codestudio/problems/find-the-team-size_2117109?topList=top-100-sql-problems&leftPanelTab=1
select
    employee_id,
    team.team_size
from
    employee
    join (
        select
            team_id,
            count(team_id) as "team_size"
        from
            employee
        group by
            team_id
    ) team on employee.team_id = team.team_id
order by
    employee_id;

--https://www.codingninjas.com/codestudio/problems/shortest-distence-in-a-line_2105463?topList=top-100-sql-problems&leftPanelTab=1
select
    min(diff) as "shortest"
from
    (
        select
            (
                x - LAG(x, 1) OVER (
                    order by
                        x asc
                )
            ) as "diff"
        from
            point
    ) d;

--https://www.codingninjas.com/codestudio/problems/count-student-number-in-departments_2119332?topList=top-100-sql-problems&leftPanelTab=2
select
    distinct dept_name,
    count(student_id) as "student_number"
from
    student s
    right join department d on s.dept_id = d.dept_id
group by
    dept_name
order by
    student_number desc,
    dept_name;

--https://www.codingninjas.com/codestudio/problems/imdb_1755912?topList=top-100-sql-problems&leftPanelTab=1
select
    genre,
    max(domestic + worldwide - budget) as net_profit
from
    genre,
    earning,
    IMDB
where
    genre.movie_id = earning.movie_id
    and genre.movie_id = imdb.movie_id
    and genre is not null
    and title like '%2012%'
group by
    genre
order by
    genre;

--Cross join - https://www.codingninjas.com/codestudio/problems/all-valid-triplets-that-can-represent-a-country_2196165?topList=top-100-sql-problems&leftPanelTab=1
select
    a.student_name as member_A,
    b.student_name as member_B,
    c.student_name as member_C
from
    SchoolA a,
    SchoolB b,
    SchoolC c
where
    a.student_name != b.student_name
    and a.student_name != c.student_name
    and b.student_name != c.student_name
    and a.student_id != b.student_id
    and a.student_id != c.student_id
    and b.student_id != c.student_id;

--https://www.codingninjas.com/codestudio/problems/countries-you-can-safely-invest-in_2188774?topList=top-100-sql-problems&leftPanelTab=0
select
    country
from
    (
        select
            co.name as country,
            avg(duration) as average
        from
            Country co,
            Person p,
            Calls ca
        where
            p.phone_number LIKE co.country_code || '%'
            and (
                p.id = ca.caller_id
                OR p.id = ca.callee_id
            )
        group by
            co.name
    ) temp_table
where
    temp_table.average > (
        select
            AVG(duration) as global_average
        from
            calls
    );