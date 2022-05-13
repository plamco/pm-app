using Moq;
using NUnit.Framework;
using ProjectManagementApp.Data.Models;
using ProjectManagementApp.Data.Services;
using System;
using AppTask = ProjectManagementApp.Data.Models.Task;
using Task = System.Threading.Tasks.Task;

namespace ProjectManagementApp.Tests
{
    public class TaskTests
    {
        private AppTask _existingTask;
        private Mock<IRepository<AppTask>> _taskRepo;
        private Mock<IRepository<History>> _historyRepo;
        private TaskService _service;

        [SetUp]
        public void SetUp()
        {
            _existingTask = new AppTask(Guid.NewGuid(), "", "", "", "", "", "", 1, DateTime.UtcNow);

            _taskRepo = new Mock<IRepository<AppTask>>();
            _taskRepo.Setup(x => x.GetAsync(It.IsAny<Guid>())).Returns(Task.FromResult(_existingTask));
            _taskRepo.Setup(x => x.UpdateAsync(It.IsAny<AppTask>(), It.IsAny<AppTask>())).Returns(Task.CompletedTask);

            _historyRepo = new Mock<IRepository<History>>();
            _historyRepo.Setup(x => x.InsertAsync(It.IsAny<History>())).Returns(Task.CompletedTask);

            _service = new TaskService(_taskRepo.Object, _historyRepo.Object);
        }

        [Test]
        public async Task Edit_ChecksTaskExists()
        {
            await _service.UpdateAsync(_existingTask);

            _taskRepo.Verify(x => x.GetAsync(_existingTask.ID), Times.Once);
        }

        [Test]
        public async Task Edit_CreatesHistory()
        {
            await _service.UpdateAsync(_existingTask);

            _historyRepo.Verify(x => x.InsertAsync(It.IsAny<History>()), Times.Once);
        }

        [Test]
        public async Task Edit_CallsUpdateTask()
        {
            var newTask = new AppTask(_existingTask.ID, "", "New desc", "", "", "", "", 1, DateTime.UtcNow);
            await _service.UpdateAsync(newTask);

            _taskRepo.Verify(x => x.UpdateAsync(newTask, It.IsAny<AppTask>()), Times.Once);
        }
    }
}