#### What is the point of an aggregate?

It operates to a large degree as one thing. 
The Aggregate Root is the single entity that controls access to the children.

Aggregates provide a clean pattern to keep logic where it really belongs

Aggregate Root can be dealt with by a repository.

#### Restrictions on aggregates and aggregate roots


DDD is really just “OO software done right”


# code review
catch bugs
catch code quality issues
a learning opportunity
an exchange of best practices and experiences
a chance to synchronize

lead to better sw
win-win

dark side
amplifier: the good, the bad
  healthy culture

if the culture is not healthy, code review never pays off

#zdtip cron expression
ITrigger trigger = TriggerBuilder.Create()
       .WithCronSchedule("0 0 8 ? * MON-FRI *")
       .Build();

### this works, every 5 seconds
"HelloWorldJob": "0/5 * * * * ?"
### this works, at 7pm every weekday
"HelloWorldJob": "0 0 19 ? * MON-FRI *"
### this works, at 7:15pm every weekday
"HelloWorldJob": "0 15 19 ? * MON-FRI *"


### This should fire every day at 8am except for weekend
var trigger = TriggerBuilder
                 .Create()
                 .WithSchedule(CronScheduleBuilder
                                  .AtHourAndMinuteOnGivenDaysOfWeek(8,
                                                                    0,
                                                                    DayOfWeek.Monday,
                                                                    DayOfWeek.Tuesday,
                                                                    DayOfWeek.Wednesday,
                                                                    DayOfWeek.Thursday,
                                                                    DayOfWeek.Friday))
                 .Build();