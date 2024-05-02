using System.Collections.Generic;

namespace NovaDrift.Scripts.Systems;

public class AbilityTree
{
    public int Id;
    public int StartAbilityId;
    public List<int> MiddleAbilityIds;
    public int EndAbilityId;
}