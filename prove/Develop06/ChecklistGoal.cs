class ChecklistGoal : Goal {
    private int _target;
    private int _bonus;

    public ChecklistGoal(String name, String description, int points, int target, int bonus) :
            base(name, description, points) {
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent() {
        GetEvents().Add(new Event());
    }

    public override bool IsComplete() {
        if (GetEvents().Count >= _target) {
            return true;
        } else {
            return false;
        }
    }

    public override int GetScore() {
        int result = 0;
        result += GetEvents().Count * GetPoints();
        if (IsComplete()) {
            result += _bonus;
        }

        return result;
    }

    public override String GetStringRepresentation() {
        return $"{base.GetStringRepresentation()} --- Currently completed: {GetEvents().Count}/{_target}";
    }

    public override String GetDetailsString() {
        return $"{GetName()},{GetDescription()},{GetPoints()},{_target},{_bonus}";
    }
}