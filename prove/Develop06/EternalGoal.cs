class EternalGoal : Goal {
    public EternalGoal(String name, String description, int points) :
        base(name, description, points) {}

    public override void RecordEvent() {
        GetEvents().Add(new Event());
    }

    public override bool IsComplete() {
        return false;
    }

    public override String GetDetailsString() {
        return $"{GetName()},{GetDescription()},{GetPoints()}";
    }

    public override int GetScore() {
        return GetPoints() * GetEvents().Count;
    }
}