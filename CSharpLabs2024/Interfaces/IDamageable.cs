namespace CSharpLabs2024.Interfaces;

public interface IDamageable
{
    string Name { get; }
    int Health { get; set; }
    void TakeDamage(int damage);
    void ShowStats();
    void SelectActions(IDamageable target);
}