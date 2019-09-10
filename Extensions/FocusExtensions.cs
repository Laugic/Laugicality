using Laugicality.Focuses;

namespace Laugicality.Extensions
{
    public static class FocusExtensions
    {
        public static bool IsCapacity(this Focus focus) => focus == FocusManager.Instance.Capacity;
        public static bool IsFerocity(this Focus focus) => focus == FocusManager.Instance.Ferocity;
        public static bool IsMobility(this Focus focus) => focus == FocusManager.Instance.Mobility;
        public static bool IsTenacity(this Focus focus) => focus == FocusManager.Instance.Tenacity;
        public static bool IsUtility(this Focus focus) => focus == FocusManager.Instance.Utility;
        public static bool IsVitality(this Focus focus) => focus == FocusManager.Instance.Vitality;
    }
}