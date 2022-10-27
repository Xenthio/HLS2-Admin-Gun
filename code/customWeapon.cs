using Sandbox;
class CoolGun : Weapon
{
    public override string InventoryIcon => "/ui/admingun.png";
    public override string InventoryIconSelected => "/ui/admingun.png";
    public override float PrimaryRate => 0.001f;
    public override float ReloadTime => 0.01f;
    public override int Bucket => 1;
    public override int BucketWeight => 3;
    public override void AttackPrimary()
    {
        base.AttackPrimary();
        if ( IsClient ) return;
        ShootBullet( 0f, 100, 100, 1 );
    }
    public override void AttackSecondary()
    {
        base.AttackSecondary();
        if ( IsClient ) return;
        var tr = Trace.Ray( Owner.EyePosition, Owner.EyePosition + Owner.EyeRotation.Forward * 10000 ).Ignore(Owner).Run();
        HLExplosion.Explosion( this, Owner, tr.EndPosition, 250, 100, 24.0f, "grenade" );
    }
}