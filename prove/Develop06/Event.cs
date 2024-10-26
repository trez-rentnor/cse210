class Event {
    private DateTime _timestamp;

    public Event (DateTime? timestamp = null) {
        _timestamp = timestamp ?? DateTime.Now;
    }

    public String GetEventTime() {
        return _timestamp.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public String GetDetailsString() {
        return $"{_timestamp.ToString()}";
    }
}