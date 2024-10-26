class SimpleGoal : Goal {
    public SimpleGoal(String name, String description, int points, bool isComplete = false) :
            base(name, description, points) { }

    public override void RecordEvent() {
        GetEvents().Add(new Event());
    }

    public override bool IsComplete() {
        return GetEvents().Count > 0;
    }

    public override String GetDetailsString() {
        return $"{GetName()},{GetDescription()},{GetPoints()}";
    }

    public override int GetScore() {
        if (IsComplete()) {
            return GetPoints();
        } else {
            return 0;
        }
    }
}