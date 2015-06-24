// Copyright (c) Microsoft. All rights reserved.

#include "pch.h"
#include "Scenario1_Message.xaml.h"

using namespace CredentialPicker;
using namespace SDKTemplate;

using namespace concurrency;
using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::Security::Credentials::UI;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

Scenario1_Message::Scenario1_Message()
{
    InitializeComponent();
}

void Scenario1_Message::SetResult(CredentialPickerResults^ result)
{
    auto domainName = result->CredentialDomainName;
    auto userName = result->CredentialUserName;
    auto password = result->CredentialPassword;
    auto savedByApi = result->CredentialSaved;
    auto saveOption = result->CredentialSaveOption;
    
    Status->Text = "OK";
    Domain->Text = domainName;
    Username->Text = userName;
    Password->Text = password;
    CredentialSaved->Text = (savedByApi ? "true" : "false");

    switch (result->CredentialSaveOption)
    {
    case Windows::Security::Credentials::UI::CredentialSaveOption::Hidden:
        CheckboxState->Text = "Hidden";
        break;
    case Windows::Security::Credentials::UI::CredentialSaveOption::Selected:
        CheckboxState->Text = "Selected";
        break;
    case Windows::Security::Credentials::UI::CredentialSaveOption::Unselected:
        CheckboxState->Text = "Unselected";
        break;
    }
}

void Scenario1_Message::Launch_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    if ((Message->Text != nullptr) && (Target->Text != nullptr))
    {
        create_task(Windows::Security::Credentials::UI::CredentialPicker::PickAsync(Target->Text, Message->Text))
            .then([this](CredentialPickerResults^ credPickerResult)
        {
            auto domainName = credPickerResult->CredentialDomainName;
            auto userName = credPickerResult->CredentialUserName;
            auto password = credPickerResult->CredentialPassword;
            auto savedByApi = credPickerResult->CredentialSaved;
            auto saveOption = credPickerResult->CredentialSaveOption;
            SetResult(credPickerResult);
        });
    }
}

