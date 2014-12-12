# microsecondDateTime

Simple function to use microsecond from DateTime Structure in C#:

```csharp  
double microsecondDateTime(DateTime date)
{
	DateTime withoutMicrosecondDate = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
	return (double)(date.Ticks - withoutMicrosecondDate.Ticks) / (TimeSpan.TicksPerMillisecond / 1000);
}
```

In the files are some example code.