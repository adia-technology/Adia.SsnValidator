# Changelog

## 0.1.0

* **BREAKING CHANGE** Changed the main validation class to be `SsnValidator`. This is the only publicly available class in the library.
* `SsnValidator.Validate` returns a `ValidationResult` instance that can be used to determine why an SSN is invalid.

## 0.0.1

Initial version with support for Swiss SSN (AHV).
