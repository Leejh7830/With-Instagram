using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace With_Instagram
{
    class UIManager
    {
        private readonly List<User> users;
        DateTime now = DateTime.Now;

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

        public void UpdateDGV(DataGridView dgvUser)
        {
            try
            {
                // DataGridView 초기화
                dgvUser.Rows.Clear();

                // DataGridView에 사용자 정보 출력
                foreach (User user in users)
                {
                    // No 열에 들어갈 값은 현재 줄 수
                    string noValue = (dgvUser.Rows.Count).ToString();

                    // DataGridView에 행 추가
                    dgvUser.Rows.Add(noValue, user.ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DataGridView를 업데이트하는 도중 오류가 발생했습니다: {ex.Message}");
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

        public void SaveUser(string newID, string newPW, ComboBox cboxID1)
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

            MessageBox.Show("사용자가 삭제되었습니다.");

            // 사용자 정보를 파일에서 저장
            SaveUsers(users);
        }


        public void ExploreInstagram(IWebDriver driver, TextBox txtCount)
        {
            try
            {
                string CountText = txtCount.Text;
                if (string.IsNullOrWhiteSpace(CountText))
                {
                    MessageBox.Show("LikeCount에 유효한 값이 입력되지 않았습니다.");
                    return;
                }
                if (int.TryParse(CountText, out int count))
                {
                    Console.WriteLine("LikeCount: " + count);
                }
                else
                {
                    // 변환에 실패한 경우
                    MessageBox.Show("LikeCount에 유효한 숫자가 아닌 값이 입력되었습니다.");
                    return;
                }

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                // mount_0_0_XX 부분이 변경되는 경우에도 동작하는 XPath 작성
                string expXPath = "//*[starts-with(@id, 'mount_0_0_')]/div/div/div[2]/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[3]/span/div/a";

                // ElementToBeClickable을 사용하여 요소가 클릭 가능할 때까지 대기
                IWebElement divExp = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(expXPath)));
                divExp.Click();
                Console.WriteLine($"[{now.ToString("yyyy-MM-dd, tt hh:mm:ss")}] EXP 클릭 성공");

                string contentXPath = "//*[starts-with(@id, 'mount_0_0_')]/div/div/div[2]/div/div/div[1]/div[1]/div[2]/section/main/div/div[1]/div/div[1]/div[2]/div/a";
                IWebElement divContent = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(contentXPath)));
                divContent.Click();
                Console.WriteLine($"[{now.ToString("yyyy-MM-dd, tt hh:mm:ss")}] Content 클릭 성공");



                string nextXPath1 = "/html/body/div[8]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div/button";
                string nextXPath2 = "/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div[2]/button";
                string nextXPath3 = "/html/body/div[7]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div/button";
                string nextXPath4 = "/html/body/div[6]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div[2]/button";
                string nextXPath5 = "/html/body/div[8]/div[1]/div/div[3]/div/div/div/div/div[1]/div/div/div[2]/button";
                
                string[] nextXPaths = new string[] { nextXPath1, nextXPath2 , nextXPath3 , nextXPath4 , nextXPath5 };

                for (int i = 0; i < count; i++)
                {
                    string heartXpath = "/html/body/div[*]/div[1]/div/div[3]/div/div/div/div/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/div";

                    // 첫 번째 Xpath에 대한 다이나믹 Xpath
                    string firstDynamicXpath = heartXpath.Replace("div[8]", "div[*]");

                    // 두 번째 Xpath에 대한 다이나믹 Xpath
                    string secondDynamicXpath = heartXpath.Replace("div[7]", "div[*]");
                    
                    IWebElement divHeart = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(heartXpath)));

                    divHeart.Click();
                    Console.WriteLine($"[{now.ToString("yyyy-MM-dd, tt hh:mm:ss")}] Like 클릭1 성공");
                    divHeart.Click();
                    Console.WriteLine($"[{now.ToString("yyyy-MM-dd, tt hh:mm:ss")}] Like 클릭2 성공");

                    IWebElement divNext = null;

                    for (int j = 0; j < nextXPaths.Length; j++)
                    {
                        string nextXPath = nextXPaths[j];
                        try
                        {
                            divNext = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(nextXPath)));
                            divNext.Click();
                            Console.WriteLine($"[{now.ToString("yyyy-MM-dd, tt hh:mm:ss")}] Next 클릭 성공 ({j + 1}/{nextXPaths.Length})");
                            break; // 성공적으로 찾았을 때 루프 탈출
                        }
                        catch (WebDriverTimeoutException)
                        {
                            // 다음 XPath로 시도
                        }
                    }

                    if (divNext == null)
                    {
                        Console.WriteLine("Next 버튼을 찾을 수 없습니다. 반복을 중지합니다.");
                        break;
                    }
                    Thread.Sleep(2000);
                }
                MessageBox.Show("종료");

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

        // 두 컨트롤의 위치를 교환하는 함수
        public void SwapControlLocations(Control control1, Control control2)
        {
            Point tempLocation = control1.Location;
            control1.Location = control2.Location;
            control2.Location = tempLocation;
        }

        public bool IsUrlChanged(IWebDriver driver ,string newUrl)
        {
            // 현재 URL과 비교하여 변경되었는지 확인
            return !driver.Url.Equals(newUrl);
        }
    }
}
