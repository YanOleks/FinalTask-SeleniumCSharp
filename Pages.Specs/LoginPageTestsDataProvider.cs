namespace Pages.Specs
{
    public static class LoginPageTestDataProvider
    {
        public static IEnumerable<TestCaseData> GetInvalidUsernameTestData()
        {
            yield return new TestCaseData("dsf", "dsfasd", "Username is required");
        }

        public static IEnumerable<TestCaseData> GetInvalidPasswordTestData()
        {
            yield return new TestCaseData("standard_user", "dsfasd", "Password is required");
        }

        public static IEnumerable<TestCaseData> GetValidLoginTestData()
        {
            yield return new TestCaseData("standard_user", "secret_sauce", "Swag Labs");
        }
    }
}
