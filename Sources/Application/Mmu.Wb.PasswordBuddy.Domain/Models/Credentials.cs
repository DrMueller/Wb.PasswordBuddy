using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class Credentials
    {
        private readonly List<Credential> _values;

        public Credentials(List<Credential> values)
        {
            _values = values;
        }

        public IReadOnlyCollection<Credential> Values => _values.DeepCopy();

        public void RemoveCredential(string credentialId)
        {
            _values.RemoveAll(f => f.Id == credentialId);
        }

        public void UpsertCredential(Credential cred)
        {
            var existingCred = _values.FirstOrDefault(f => f.Id == cred.Id);

            if (existingCred != null)
            {
                _values.Remove(existingCred);
            }

            cred.UpdateLateChanged();
            _values.Add(cred);
        }
    }
}