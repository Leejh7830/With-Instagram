using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace With_Instagram
{
    class UIManager
    {
        private readonly List<User> users;

        public UIManager()
        {
            users = new List<User>();
        }



        public void LoadUsers(ComboBox cboxID1)
        {
            try
            {
                // 파일에서 사용자 정보 읽기
                string filePath = "users.dat";
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            User user = new User
                            {
                                ID = parts[0],
                                Password = parts[1]
                            };
                            users.Add(user);
                            cboxID1.Items.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 정보를 불러오는 도중 오류가 발생했습니다: {ex.Message}");
            }
        }

        public void SaveUsers()
        {
            try
            {
                // 사용자 정보를 파일에 저장
                string filePath = "users.dat";

                // 파일이 존재하지 않으면 새로 생성
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                // 파일에 사용자 정보 작성
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (User user in users)
                    {
                        writer.WriteLine($"{user.ID},{user.Password}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 정보를 저장하는 도중 오류가 발생했습니다: {ex.Message}");
            }
        }

        public void SaveUsers(List<User> userList)
        {
            try
            {
                // 사용자 정보를 파일에 저장
                string filePath = "users.dat";

                // 파일이 존재하지 않으면 새로 생성
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                // 파일에 사용자 정보 작성
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (User user in userList)
                    {
                        // 파일에 사용자 정보 작성
                        writer.WriteLine($"{user.ID},{user.Password}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사용자 정보를 저장하는 도중 오류가 발생했습니다: {ex.Message}");
            }
        }

        public bool IsInputValid(string newID, string newPW)
        {
            // 사용자가 ID와 PW를 입력했는지 확인
            if (string.IsNullOrWhiteSpace(newID) || string.IsNullOrWhiteSpace(newPW))
            {
                MessageBox.Show("ID와 비밀번호를 모두 입력하세요.");
                return false;
            }
            return true;
        }

        public void AddOrUpdateUser(string newID, string newPW, ComboBox cboxID1)
        {
            // 이미 동일한 ID가 있는지 확인
            User existingUser = users.FirstOrDefault(user => user.ID == newID);

            if (existingUser != null)
            {
                // 이미 있는 사용자의 비밀번호를 업데이트
                existingUser.Password = newPW;
                SaveUsers(users);
                MessageBox.Show("비밀번호가 업데이트되었습니다.");
            }
            else
            {
                // 새로운 사용자를 추가
                User user = new User
                {
                    ID = newID,
                    Password = newPW
                };
                users.Add(user);
                cboxID1.Items.Add(user);

                // 사용자 정보를 저장
                SaveUsers(users);

                MessageBox.Show("새로운 사용자가 추가되었습니다.");
            }
        }

        public void DeleteUser(User selectedUser, ComboBox cboxID1, TextBox txtID1, TextBox txtPW1)
        {
            // 리스트에서 선택된 사용자 제거
            users.Remove(selectedUser);

            // 콤보박스에서도 해당 사용자 제거
            cboxID1.Items.Remove(selectedUser);

            // 텍스트 상자 초기화
            txtID1.Clear();
            txtPW1.Clear();

            // 사용자가 삭제되었습니다. 메시지 표시
            MessageBox.Show("사용자가 삭제되었습니다.");

            // 사용자 정보를 파일에서 저장
            SaveUsers(users);
        }




        public void ExploreInstagram(IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

                // mount_0_0_XX 부분이 변경되는 경우에도 동작하는 XPath 작성
                string dynamicXPath = "//*[starts-with(@id, 'mount_0_0_')]/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[3]/span/div/a";

                // ElementToBeClickable을 사용하여 요소가 클릭 가능할 때까지 대기
                IWebElement divExp = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(dynamicXPath)));

                divExp.Click();
                Console.WriteLine("EXP 클릭 성공");
            }
            catch (WebDriverTimeoutException ex)
            {
                // 대기 시간이 초과되면 발생하는 예외 처리
                MessageBox.Show($"요소가 클릭 가능 상태가 되지 않았습니다. 원인: {ex.Message}");
            }
            catch (NoSuchElementException ex)
            {
                // 요소를 찾지 못한 경우 발생하는 예외 처리
                MessageBox.Show($"탐색(Explore)을 찾을 수 없습니다. 원인: {ex.Message}");
            }
        }



    }
}
