abstract class Goal {
    private String _shortName;
    private String _description;
    private int _points;
    private List<Event> _events;

    public Goal(String name, String description, int points) {
        _shortName = name;
        _description = description;
        _points = points;
        _events = new List<Event>();
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public abstract String GetDetailsString();

    public abstract int GetScore();

    public virtual String GetStringRepresentation() {
        return $"{_shortName} ({_description})";
    }

    public String GetName() {
        return _shortName;
    }

    public String GetDescription() {
        return _description;
    }

    public int GetPoints() {
        return _points;
    }

    public List<Event> GetEvents() {
        return _events;
    }
}