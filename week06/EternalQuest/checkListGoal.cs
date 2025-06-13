public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            return _currentCount == _targetCount ? _points + _bonus : _points;
        }
        return 0;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() =>
        $"[{(_currentCount >= _targetCount ? "X" : " ")}] {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal|{_name}|{_description}|{_points}|{_targetCount}|{_bonus}|{_currentCount}";
}
