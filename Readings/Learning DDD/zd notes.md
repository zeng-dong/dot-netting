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

### Conversation with a Domain Expert: Exploring the Scheduling Subdomain
### Conversation with a Domain Expert: Exploring the Scheduling Subdomain

So we'll probably want to have separate classes for appointments and surgeries. 
‑Classes? No, we refer our clients to obedience and puppy preschool classes at other facilities. We don't actually schedule any of those in the clinic themselves. ‑I'm sorry. That's a software term. In software, we have different classifications of concepts in the program, which are called classes. I'm just getting ahead of myself here. Sorry. 
‑Don't worry. We're not going to make you learn our software terms. Steve and I will try to have a little bit more self control with that. We do want to make sure we're all speaking the same language when it comes to concepts in the application though. 


‑Okay, so I have another quick question. Do we have to worry about multiple staff members scheduling appointments at the same time? ‑No, there should only ever be one person doing the scheduling at a time, although I could see if we grew in the future that could change. But I don't think that'll happen in the next couple of years. Okay, then we don't have to worry about the rare occurrence of two people creating a conflict if they're trying to schedule an appointment for different patients in the same room or with the same doctor. That'll keep things a lot simpler. And we need to know before an appointment if certain resources are available, like rooms and doctors. And then if they are and we want to schedule the appointment, then we need to be able to book the doctor, the room, and any other resources. Hey, is it okay if we refer to doctors as resources? ‑Sure, that makes sense. You know, I think it makes sense to use the term resources to refer to the doctors, the rooms, and the technicians since those are all things that can affect whether or not an appointment can be scheduled. But remember, sometimes it'll be just a vet tech in a room, and other times it might be the doctor in the room, but sometimes you might need the doctor, the technician, and a room. ‑Wow, this is a lot more complicated than we'd realized, but it's interesting. This is going to be cool to model in the application.