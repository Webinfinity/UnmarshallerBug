UnmarshallerBug
===============

This is a test case for the AWS SDK.

The method that unmarshalls the JSON response has a bug which can result in existing properties 
not being unmarshalled if the response from the API contains new properties that are not part 
of the SDK.

The cause is documented in this PR https://github.com/aws/aws-sdk-net/pull/50

Since that PR was created more work has been done on the JsonUnmarshallerContext so the PR was a 
bit outdated and closed, the issue is still present in the latest version of the SDK.

